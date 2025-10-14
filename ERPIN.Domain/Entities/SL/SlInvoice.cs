using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.SL;

[Table("SlInvoices", Schema = nameof(Schemes.SL))]
public class SlInvoice : InvoiceEntity
{
    public int CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; }

    [ForeignKey(nameof(StoreId))]
    public Store Store { get; set; }
    public List<SlInvoiceDetail> InvoiceDetail { get; set; }
}
