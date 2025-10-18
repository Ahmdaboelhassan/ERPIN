using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.PR;

[Table("PRReturns", Schema = nameof(Schemes.PR))]
public class PRReturn : InvoiceEntity
{
    [ForeignKey(nameof(VendorId))]
    public int VendorId { get; set; }

    [ForeignKey(nameof(StoreId))]
    public Store Store { get; set; }
    public ICollection<PRReturnDetail> ReturnDetails { get; set; }
}
