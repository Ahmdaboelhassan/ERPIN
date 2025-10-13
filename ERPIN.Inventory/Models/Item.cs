using ERPIN.Shared.Models;

namespace ERPIN.Inventory.Models;
public class Item : BaseEntity
{
    public required string BarCode { get; set; }
    public string? Description { get; set; }
    public string? UOM { get; set; }
    public decimal? PurchasePrice { get; set; }
    public decimal? SellPrice { get; set; }
    public bool IsActive { get; set; }

}
