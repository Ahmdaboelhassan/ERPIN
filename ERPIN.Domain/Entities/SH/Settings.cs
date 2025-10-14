using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.SH;

[Table("Settings", Schema = nameof(Schemes.ST))]

public class Settings
{
    [Key]
    public int Id { get; set; }
}
