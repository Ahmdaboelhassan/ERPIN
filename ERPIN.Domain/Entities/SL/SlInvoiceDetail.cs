using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.Entities.PR;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.SL;

[Table("SLInvoiceDetails", Schema = nameof(Schemes.SL))]
public class SLInvoiceDetail : InvoiceDetailEntity
{
    [ForeignKey(nameof(InvoiceId))]
    public SLInvoice Invoice { get; set; }

    [ForeignKey(nameof(ItemId))]
    public Item Item { get; set; }

}
