using ERPIN.Domain.Entities.SL;
using ERPIN.Domain.IRepositories;
using ERPIN.Services.DTOs.Request;
using ERPIN.Services.DTOs.Response;
using ERPIN.Services.IServices.Sales;
using ERPIN.Services.IServices.Shared;
using MapsterMapper;
using System.Threading.Tasks;

namespace ERPIN.Services.Services.Sales;
public class SLInvoiceService : ISLInvoiceService 
{
    private IUserLogService _userLogService;
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public SLInvoiceService(IUserLogService userLogService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userLogService = userLogService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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
    public async Task<ResultResponse<SLInvoiceResponse>> GetInvoice(int id)
    {
        var invoice = await _unitOfWork.SlInvoices.Get(id);
        if (invoice == null)
            return Result.Error<SLInvoiceResponse>("Invoice not found");

        var invoiceRes = _mapper.Map<SLInvoiceResponse>(invoice);

        return Result.Success(invoiceRes);
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
