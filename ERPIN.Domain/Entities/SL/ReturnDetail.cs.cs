using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.Entities.PR;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.SL;

[Table("SLReturnDetails", Schema = nameof(Schemes.SL))]
public class SLReturnDetail : InvoiceDetailEntity
{
    [ForeignKey(nameof(InvoiceId))]
    public SLReturn Invoice { get; set; }

    [ForeignKey(nameof(ItemId))]
    public Item Item { get; set; }
}
