using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.Entities.SL;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.PR;
[Table("PRInvoiceDetails", Schema = nameof(Schemes.PR))]

public class PRInvoiceDetail : InvoiceDetailEntity
{
    [ForeignKey(nameof(InvoiceId))]
    public PRInvoice Invoice  { get; set; }
    
    [ForeignKey(nameof(ItemId))]
    public Item Item { get; set; }

}
