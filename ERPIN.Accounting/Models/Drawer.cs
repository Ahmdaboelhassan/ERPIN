using ERPIN.Shared.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Accounting.Models;
public class Drawer : BaseEntity
{
    public required int AccountId { get; set; }

    [ForeignKey(nameof(AccountId))]
    public required Account Account { get; set; }
    
}
