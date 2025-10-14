using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.FI;

[Table("Drawers", Schema = nameof(Schemes.FI))]
public class Drawer : BaseEntity
{
    public required int AccountId { get; set; }

    [ForeignKey(nameof(AccountId))]
    public required Account Account { get; set; }
    
}
