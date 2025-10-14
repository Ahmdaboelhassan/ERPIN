using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.INV;

[Table("Stores", Schema = nameof(Schemes.INV))]
public class Store : BaseNamedEntity
{
    public int PurchaseAccountId { get; set; }
    public int SalesAccountId { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public bool IsActive { get; set; }

}
