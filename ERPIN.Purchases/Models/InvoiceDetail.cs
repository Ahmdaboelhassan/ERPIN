using ERPIN.Inventory.Models;
using ERPIN.Shared.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Purchases.Models;
public class InvoiceDetail : InvoiceDetailEntity
{
    [ForeignKey(nameof(InvoiceId))]
    public Invoice Invoice  { get; set; }
    
    [ForeignKey(nameof(ItemId))]
    public Item Item { get; set; }

}
