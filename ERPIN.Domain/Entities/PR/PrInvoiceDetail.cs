using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.PR;
[Table("PrInvoiceDetails", Schema = nameof(Schemes.PR))]

public class PrInvoiceDetail : InvoiceDetailEntity
{
    [ForeignKey(nameof(InvoiceId))]
    public PrInvoice Invoice  { get; set; }
    
    [ForeignKey(nameof(ItemId))]
    public Item Item { get; set; }

}
