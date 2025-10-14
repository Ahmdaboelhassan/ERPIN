using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.FI;

[Table("Accounts", Schema = nameof(Schemes.FI))]
public class Account : BaseEntity
{
    public required string Number { get; set; }
    public string? Description { get; set; }
    public int? ParentId { get; set; }
    public bool IsParent { get; set; }

}
