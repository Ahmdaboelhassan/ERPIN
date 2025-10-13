using ERPIN.Inventory.Models;
using ERPIN.Shared.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Purchases.Models;
public class Invoice : InvoiceEntity
{
    public int VendorId { get; set; }

    [ForeignKey(nameof(VendorId))]
    public Vendor Vendor { get; set; }

    [ForeignKey(nameof(StoreId))]
    public Store Store { get; set; }
    public ICollection<InvoiceDetail> invoiceDetails { get; set; }

}
