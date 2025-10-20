using ERPIN.Domain.IRepositories;
using ERPIN.Services.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPIN.Services.Services.INV;

public interface IItemsService
{
    Task<IEnumerable<SelectListItem>> GetAllSelectList();
    Task<IEnumerable<InvoiceItemResponse>> GetItemsForInvoice();
}

public class ItemsService : IItemsService
{
    private readonly IUnitOfWork _unitOfWork;
    public ItemsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SelectListItem>> GetAllSelectList()
    {
        return await _unitOfWork.Items.SelectAll(x => true, x => new SelectListItem
        {
            Value = x.Id,
            Text = x.Name,
            TextEn = x.NameEn
        });

    }

     public async Task<IEnumerable<InvoiceItemResponse>> GetItemsForInvoice()
    {
        return await _unitOfWork.Items.SelectAll(x => true, x => new InvoiceItemResponse
        {
            Id = x.Id,
            Name = x.Name,
            NameEn = x.NameEn,
            BarCode = x.BarCode,
            Code = x.Code,
            Description = x.Description,
            PurchasePrice = x.PurchasePrice,
            SellPrice = x.SellPrice,
            UOM = x.UOM,
        });
    }

}
