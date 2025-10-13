using ERPIN.Inventory.Models;
using ERPIN.Shared.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Purchases.Models;
public class ReturnDetail : InvoiceDetailEntity
{
    [ForeignKey(nameof(InvoiceId))]
    public Return Invoice { get; set; }
    
    [ForeignKey(nameof(ItemId))]
    public Item Item { get; set; }
}
