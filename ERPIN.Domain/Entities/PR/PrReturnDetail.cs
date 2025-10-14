using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.PR;
[Table("PrReturnDetails", Schema = nameof(Schemes.PR))]

public class PrReturnDetail : InvoiceDetailEntity
{
    [ForeignKey(nameof(InvoiceId))]
    public PrReturn Invoice { get; set; }
    
    [ForeignKey(nameof(ItemId))]
    public Item Item { get; set; }
}
