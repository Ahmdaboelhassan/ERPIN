using ERPIN.Inventory.Models;
using ERPIN.Shared.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPN.Sales.Models;
public class Invoice : InvoiceEntity
{
    public int CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; }

    [ForeignKey(nameof(StoreId))]
    public Store Store { get; set; }
    public List<InvoiceDetail> InvoiceDetail { get; set; }
}
