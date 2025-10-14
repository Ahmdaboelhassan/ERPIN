using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.INV;

[Table("Items", Schema = nameof(Schemes.INV))]
public class Item : BaseNamedEntity
{
    public required string BarCode { get; set; }
    public string? Description { get; set; }
    public string? UOM { get; set; }
    public decimal? PurchasePrice { get; set; }
    public decimal? SellPrice { get; set; }
    public bool IsActive { get; set; }

}
