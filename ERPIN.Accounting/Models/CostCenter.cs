using ERPIN.Shared.Models;

namespace ERPIN.Accounting.Models;
public class CostCenter : BaseEntity
{
    public required string Number { get; set; }
    public string? Description { get; set; }
    public int? ParentId { get; set; }
    public bool IsParent { get; set; }
}
