using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.INV;

[Table("ItemStores", Schema = nameof(Schemes.INV))]
public class ItemStore
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ItemId { get; set; }
    public int? StoreId { get; set; }
    public int ProcessId { get; set; }
    public int SourceId { get; set; }
    public int? Quantity { get; set; }
    public bool InTrns { get; set; }
    public decimal TotalCost { get; set; }

 }
