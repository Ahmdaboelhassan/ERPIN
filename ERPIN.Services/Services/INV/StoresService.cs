using ERPIN.Domain.IRepositories;
using ERPIN.Services.DTOs.Response;

namespace ERPIN.Services.Services.INV;

public interface IStoresService
{
    Task<IEnumerable<SelectListItem>> GetAllSelectList();
}

public class StoresService : IStoresService
{
    private readonly IUnitOfWork _unitOfWork;
    public StoresService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SelectListItem>> GetAllSelectList()
    {
        return await _unitOfWork.Stores.SelectAll(x => true, x => new SelectListItem
        {
            Value = x.Id,
            Text = x.Name,
            TextEn = x.NameEn
        });
    }
}
