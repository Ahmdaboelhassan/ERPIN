using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.Entities.PR;
using ERPIN.Domain.Enums;
using ERPIN.Domain.IRepositories;
using ERPIN.Services.DTOs.Request;
using ERPIN.Services.DTOs.Response;
using ERPIN.Services.Extinctions;
using ERPIN.Services.Models;
using ERPIN.Services.Services.Shared;
using MapsterMapper;
using Microsoft.AspNetCore.Http;

namespace ERPIN.Services.Services.Purchases;

public interface IPRInvoiceService
{
    Task<ResultResponse<int>> CreateInvoice(CreatePRInvoice model);
    Task<ResultResponse<int>> DeleteInvoice(int id);
    Task<ResultResponse<int>> EditInvoice(CreatePRInvoice model);
    Task<ResultResponse<PRInvoiceResponse>> GetInvoice(int id);
    Task<ResultResponse<int>> GetNextCode();
    Task<ResultResponse<CreatePRInvoice>> NewInvoice();
}

public class PRInvoiceService : IPRInvoiceService
{

    private readonly IUserLogService _userLogService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly int currentUserId;

    public PRInvoiceService(IUserLogService userLogService, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContext)
    {
        _userLogService = userLogService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        currentUserId = httpContext.HttpContext.GetUserId();
    }

    public async Task<ResultResponse<CreatePRInvoice>> NewInvoice()
    {

        var code = await GetNextCode();

        var model = new CreatePRInvoice()
        {
            Code = code.Data,
            InvoiceDetails = new List<CreatePRInvoiceDetail>()
        };

        return Result.Success(model);
    }
    public async Task<ResultResponse<PRInvoiceResponse>> GetInvoice(int id)
    {
        var invoice = await _unitOfWork.PRInvoices.Get(x => x.Id == id, "InvoiceDetails");
        if (invoice == null)
            return Result.Error<PRInvoiceResponse>("Invoice not found");

        var invoiceRes = _mapper.Map<PRInvoiceResponse>(invoice);

        return Result.Success(invoiceRes);
    }

    public async Task<ResultResponse<int>> CreateInvoice(CreatePRInvoice model)
    {
        // Add Invoice Data 
        if (model.InvoiceDetails == null || model.InvoiceDetails.Count == 0)
            return Result.Error<int>("Invoice must have at least one item");

        if (model.Paid > model.Net)
            return Result.Error<int>("Paid amount cannot be greater than total amount");

        var defaultStore = await _unitOfWork.Stores.GetFirst();
        var defaultVendor = await _unitOfWork.Vendors.GetFirst();

        if (defaultStore == null || defaultVendor == null)
            return Result.Error<int>("No store or customer found, please create a store first");

        var invoice = _mapper.Map<PRInvoice>(model);

        invoice.CreatedBy = currentUserId;
        invoice.CreatedAt = DateTime.Now;
        invoice.StoreId = defaultStore.Id;
        invoice.VendorId = defaultVendor.Id;


        // Create Item Store 
        await _unitOfWork.PRInvoices.AddAsync(invoice);
        await _unitOfWork.SaveChangesAsync();

        var itemStores = model.InvoiceDetails
            .Select(g => new ItemStore
            {
                ItemId = g.ItemId,
                InTrns = true,
                ProcessId = (int)Process.PurchaseInvoice,
                Quantity = g.Quantity,
                CreatedAt = DateTime.Now,
                SourceId = invoice.Id,
                TotalCost = g.Quantity * g.UnitPrice
            }).ToList();

        await _unitOfWork.ItemStores.AddRange(itemStores);
        await _unitOfWork.SaveChangesAsync();

        // Create User Log
        await _userLogService.LogUserActivityAsync(new CreateUserLog
        {
            Code = invoice.Code,
            Action = (int)UserAction.Create,
            Process = (int)Process.PurchaseInvoice,
            Notes = model.Note
        });

        return Result.Success(invoice.Id);
    }

    public async Task<ResultResponse<int>> EditInvoice(CreatePRInvoice model)
    {
        var invoice = await _unitOfWork.PRInvoices.Get(m => m.Id == model.Id, "InvoiceDetails");
        if (invoice == null)
            return Result.Error<int>("Invoice not found");

        // Add Invoice Data 
        if (model.InvoiceDetails == null || model.InvoiceDetails.Count == 0)
            return Result.Error<int>("Invoice must have at least one item");

        if (model.Paid > model.Net)
            return Result.Error<int>("Paid amount cannot be greater than total amount");


        invoice.UpdateBy = currentUserId;
        invoice.UpdatedAt = DateTime.Now;

        // Remove existing details
        _unitOfWork.PRInvoiceDetails.DeleteRange(invoice.InvoiceDetails);
        invoice.InvoiceDetails.Clear();
        await _unitOfWork.SaveChangesAsync();

        _mapper.Map(model, invoice);

        // Create Item Store 
        _unitOfWork.PRInvoices.Update(invoice);
        await _unitOfWork.SaveChangesAsync();

        var oldItemStore = await _unitOfWork.ItemStores
            .GetAll(i => i.ProcessId == (int)Process.PurchaseInvoice && i.SourceId == invoice.Id);

        _unitOfWork.ItemStores.DeleteRange(oldItemStore);

        var itemStores = model.InvoiceDetails
            .Select(g => new ItemStore
            {
                ItemId = g.ItemId,
                InTrns = true,
                ProcessId = (int)Process.PurchaseInvoice,
                Quantity = g.Quantity,
                CreatedAt = DateTime.Now,
                SourceId = invoice.Id,
                TotalCost = g.Quantity * g.UnitPrice
            }).ToList();

        await _unitOfWork.ItemStores.AddRange(itemStores);
        await _unitOfWork.SaveChangesAsync();

        // Create User Log
        await _userLogService.LogUserActivityAsync(new CreateUserLog
        {
            Code = invoice.Code,
            Action = (int)UserAction.Update,
            Process = (int)Process.PurchaseInvoice,
            Notes = invoice.Note
        });

        return Result.Success(invoice.Id);
    }
    public async Task<ResultResponse<int>> DeleteInvoice(int id)
    {
        var invoice = await _unitOfWork.PRInvoices.Get(m => m.Id == id);
        if (invoice == null)
            return Result.Error<int>("Invoice not found");


        invoice.DeletedBy = currentUserId;
        invoice.DeletedAt = DateTime.Now;
        invoice.IsDeleted = true;
        _unitOfWork.PRInvoices.Update(invoice);

        await _unitOfWork.PRInvoiceDetails.ExecuteUpdateAsync(m => m.InvoiceId == id, m => m.SetProperty(x => x.IsDeleted, true));
        await _unitOfWork.SaveChangesAsync();

        // Create User Log
        await _userLogService.LogUserActivityAsync(new CreateUserLog
        {
            Code = invoice.Code,
            Action = (int)UserAction.Delete,
            Process = (int)Process.PurchaseInvoice,
            Notes = invoice.Note
        });

        return Result.Success(invoice.Id);
    }

    public async Task<ResultResponse<int>> GetNextCode()
    {
        var count = await _unitOfWork.PRInvoices.Count(x => true);

        return Result.Success(count + 1);
    }
}
