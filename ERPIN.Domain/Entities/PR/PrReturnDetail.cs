using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.PR;
[Table("PRReturnDetails", Schema = nameof(Schemes.PR))]

public class PRReturnDetail : InvoiceDetailEntity
{
    [ForeignKey(nameof(InvoiceId))]
    public PRReturn Invoice { get; set; }
    
    [ForeignKey(nameof(ItemId))]
    public Item Item { get; set; }
}
