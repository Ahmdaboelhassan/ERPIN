using ERPIN.Inventory.Models;
using ERPIN.Shared.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Purchases.Models;
public class Return : InvoiceEntity
{
    [ForeignKey(nameof(VendorId))]
    public int VendorId { get; set; }

    [ForeignKey(nameof(StoreId))]
    public Store Store { get; set; }
    public ICollection<ReturnDetail> ReturnDetails { get; set; }
}
