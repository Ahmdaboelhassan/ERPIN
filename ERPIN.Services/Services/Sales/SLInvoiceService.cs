using ERPIN.Domain.Entities.SL;
using ERPIN.Domain.IRepositories;
using ERPIN.Services.DTOs.Request;
using ERPIN.Services.DTOs.Response;
using ERPIN.Services.IServices.Sales;
using ERPIN.Services.IServices.Shared;
using System.Threading.Tasks;

namespace ERPIN.Services.Services.Sales;
public class SLInvoiceService : ISLInvoiceService 
{
    private IUserLogService _userLogService;
    private IUnitOfWork _unitOfWork;

    public SLInvoiceService(IUserLogService userLogService, IUnitOfWork unitOfWork)
    {
        _userLogService = userLogService;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultResponse<CreateSLReturn>> NewInvoice() {

        var code = await GetNextCode();

        var model = new CreateSLReturn()
        {
            Code = code.Data,
            //InvoiceDetails = new List<CreateSLInvoiceDetail>()
        };

        return Result.Success(model);
    }
    public async Task<ResultResponse<SlInvoice>> GetInvoice(int id)
    {
        var invoice = await _unitOfWork.SlInvoices.Get(id);
        if (invoice == null)
            return Result.Error<SlInvoice>("Invoice not found");

        return Result.Success(invoice);
    }

    public ResultResponse<int> CreateInvoice(CreateSLReturn model)
    {
        throw new NotImplementedException();
    }
  
    public ResultResponse<int> EditInvoice(CreateSLReturn model)
    {
        throw new NotImplementedException();
    }
    public ResultResponse<int> DeleteInvoice(CreateSLReturn model)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultResponse<int>> GetNextCode()
    {
        var count = await _unitOfWork.SlInvoices.Count(x => true);

        return Result.Success(count + 1);
    }

}
