using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.PR;

[Table("PrReturns", Schema = nameof(Schemes.PR))]
public class PrReturn : InvoiceEntity
{
    [ForeignKey(nameof(VendorId))]
    public int VendorId { get; set; }

    [ForeignKey(nameof(StoreId))]
    public Store Store { get; set; }
    public ICollection<PrReturnDetail> ReturnDetails { get; set; }
}
