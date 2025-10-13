using ERPIN.Shared.Models;

namespace ERPIN.Inventory.Models;
public class Store : BaseEntity
{
    public int PurchaseAccountId { get; set; }
    public int SalesAccountId { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public bool IsActive { get; set; }

}
