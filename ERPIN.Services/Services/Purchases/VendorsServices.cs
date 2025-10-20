using ERPIN.Domain.IRepositories;
using ERPIN.Services.DTOs.Response;

namespace ERPIN.Services.Services.Purchases;

public interface IVendorsServices
{
    Task<IEnumerable<SelectListItem>> GetAllSelectList();
}

public class VendorsServices : IVendorsServices
{
    private readonly IUnitOfWork _unitOfWork;
    public VendorsServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SelectListItem>> GetAllSelectList()
    {
        return await _unitOfWork.Vendors.SelectAll(x => true, x => new SelectListItem
        {
            Value = x.Id,
            Text = x.Name,
            TextEn = x.NameEn
        });
    }
}
