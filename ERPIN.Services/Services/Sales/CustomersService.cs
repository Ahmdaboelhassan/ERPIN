using ERPIN.Domain.IRepositories;
using ERPIN.Services.DTOs.Response;

namespace ERPIN.Services.Services.Sales;

public interface ICustomersService
{
    Task<IEnumerable<SelectListItem>> GetAllSelectList();
}

public class CustomersService : ICustomersService
{

    private readonly IUnitOfWork _unitOfWork;
    public CustomersService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SelectListItem>> GetAllSelectList()
    {
        return await _unitOfWork.Customers.SelectAll(x => true, x => new SelectListItem
        {
            Value = x.Id,
            Text = x.Name,
            TextEn = x.NameEn
        });
    }
}
