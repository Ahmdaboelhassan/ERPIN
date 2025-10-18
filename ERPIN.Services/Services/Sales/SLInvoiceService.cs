using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.Entities.SL;
using ERPIN.Domain.Enums;
using ERPIN.Domain.IRepositories;
using ERPIN.Services.DTOs.Request;
using ERPIN.Services.DTOs.Response;
using ERPIN.Services.Extinctions;
using ERPIN.Services.Models;
using ERPIN.Services.Services.Shared;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using UserAction = ERPIN.Domain.Enums.UserAction;

namespace ERPIN.Services.Services.Sales;

public interface ISLInvoiceService
{
    Task<ResultResponse<CreateSLInvoice>> NewInvoice();
    Task<ResultResponse<SLInvoiceResponse>> GetInvoice(int id);
    Task<ResultResponse<int>> CreateInvoice(CreateSLInvoice model);
    Task<ResultResponse<int>> EditInvoice(CreateSLInvoice model);
    Task<ResultResponse<int>> DeleteInvoice(int id);
    Task<ResultResponse<int>> GetNextCode();
}

public class SLInvoiceService : ISLInvoiceService
{
    private readonly IUserLogService _userLogService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly int currentUserId;

    public SLInvoiceService(IUserLogService userLogService, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContext)
    {
        _userLogService = userLogService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        currentUserId = httpContext.HttpContext.GetUserId();
    }

    public async Task<ResultResponse<CreateSLInvoice>> NewInvoice()
    {

        var code = await GetNextCode();

        var model = new CreateSLInvoice()
        {
            Code = code.Data,
            InvoiceDetails = new List<CreateSLInvoiceDetail>()
        };

        return Result.Success(model);
    }
    public async Task<ResultResponse<SLInvoiceResponse>> GetInvoice(int id)
    {
        var invoice = await _unitOfWork.SLInvoices.Get(x => x.Id == id , "InvoiceDetails");
        if (invoice == null)
            return Result.Error<SLInvoiceResponse>("Invoice not found");

        var invoiceRes = _mapper.Map<SLInvoiceResponse>(invoice);

        return Result.Success(invoiceRes);
    }

    public async Task<ResultResponse<int>> CreateInvoice(CreateSLInvoice model)
    {
        // Add Invoice Data 
        if (model.InvoiceDetails == null || model.InvoiceDetails.Count == 0)
            return Result.Error<int>("Invoice must have at least one item");

        if (model.Paid > model.Net)
            return Result.Error<int>("Paid amount cannot be greater than total amount");

        var defaultStore = await _unitOfWork.Stores.GetFirst();
        var defaultCustomer = await _unitOfWork.Customers.GetFirst();

        if (defaultStore == null || defaultCustomer == null)
            return Result.Error<int>("No store or customer found, please create a store first");

        var invoice = _mapper.Map<SLInvoice>(model);

        invoice.CreatedBy = currentUserId;
        invoice.CreatedAt = DateTime.Now;
        invoice.StoreId =  defaultStore.Id;
        invoice.CustomerId = defaultCustomer.Id;


        // Create Item Store 
        await _unitOfWork.SLInvoices.AddAsync(invoice);
        await _unitOfWork.SaveChangesAsync();

        var itemStores = model.InvoiceDetails
            .Select(g => new ItemStore
            {
                ItemId = g.ItemId,
                InTrns = false,
                ProcessId = (int)Process.SalesInvoice,
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
            Process = (int)Process.SalesInvoice,
            Notes = model.Note
        });

        return Result.Success(invoice.Id);
    }

    public async Task<ResultResponse<int>> EditInvoice(CreateSLInvoice model)
    {
        var invoice = await _unitOfWork.SLInvoices.Get(m => m.Id == model.Id, "InvoiceDetails");
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
        _unitOfWork.SLInvoiceDetails.DeleteRange(invoice.InvoiceDetails);
        invoice.InvoiceDetails.Clear();
        await _unitOfWork.SaveChangesAsync();
        
        _mapper.Map(model,invoice);

        // Create Item Store 
        _unitOfWork.SLInvoices.Update(invoice);
        await _unitOfWork.SaveChangesAsync();

        var oldItemStore = await _unitOfWork.ItemStores
            .GetAll(i => i.ProcessId == (int)Process.SalesInvoice && i.SourceId == invoice.Id);

        _unitOfWork.ItemStores.DeleteRange(oldItemStore);

        var itemStores = model.InvoiceDetails
            .Select(g => new ItemStore
            {
                ItemId = g.ItemId,
                InTrns = false,
                ProcessId = (int)Process.SalesInvoice,
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
            Process = (int)Process.SalesInvoice,
            Notes = invoice.Note
        });

        return Result.Success(invoice.Id);
    }
    public async Task<ResultResponse<int>> DeleteInvoice(int id)
    {
        var invoice = await _unitOfWork.SLInvoices.Get(m => m.Id == id);
        if (invoice == null)
            return Result.Error<int>("Invoice not found");


        invoice.DeletedBy = currentUserId;
        invoice.DeletedAt = DateTime.Now;
        invoice.IsDeleted = true;
        _unitOfWork.SLInvoices.Update(invoice);

        await _unitOfWork.SLInvoiceDetails.ExecuteUpdateAsync(m => m.InvoiceId == id, m => m.SetProperty(x => x.IsDeleted, true));
        await _unitOfWork.SaveChangesAsync();

        // Create User Log
        await _userLogService.LogUserActivityAsync(new CreateUserLog
        {
            Code = invoice.Code,
            Action = (int)UserAction.Delete,
            Process = (int)Process.SalesInvoice,
            Notes = invoice.Note
        });

        return Result.Success(invoice.Id);
    }

    public async Task<ResultResponse<int>> GetNextCode()
    {
        var count = await _unitOfWork.SLInvoices.Count(x => true);

        return Result.Success(count + 1);
    }

}
