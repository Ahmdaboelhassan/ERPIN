using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.PR;

[Table("PRInvoices", Schema = nameof(Schemes.PR))]

public class PRInvoice : InvoiceEntity
{
    public int VendorId { get; set; }

    [ForeignKey(nameof(VendorId))]
    public Vendor Vendor { get; set; }

    [ForeignKey(nameof(StoreId))]
    public Store Store { get; set; }
    public ICollection<PRInvoiceDetail> InvoiceDetails { get; set; }

}
