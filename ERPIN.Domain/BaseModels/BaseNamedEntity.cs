using ERPIN.Domain.BaseModels.IModels;
using System.ComponentModel.DataAnnotations;

namespace ERPIN.Domain.BaseModels;
public class BaseNamedEntity : IBaseEntity, INameEntity
{
    [Key]
    public int Id { get ; set ; }
    public int Code { get; set; }
    public string Name { get; set; }
    public string? NameEn { get; set; }
    public DateTime CreatedAt { get ; set ; }
    public DateTime? UpdatedAt { get ; set ; }
    public DateTime? DeletedAt { get ; set ; }
    public int CreatedBy { get ; set ; }
    public int? UpdateBy { get ; set ; }
    public int? DeletedBy { get ; set ; }
    public bool IsDeleted { get ; set ; }
}
