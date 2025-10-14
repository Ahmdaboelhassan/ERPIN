using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.FI;

[Table("CostCenters", Schema = nameof(Schemes.FI))]
public class CostCenter : BaseNamedEntity
{
    public required string Number { get; set; }
    public string? Description { get; set; }
    public int? ParentId { get; set; }
    public bool IsParent { get; set; }
}
