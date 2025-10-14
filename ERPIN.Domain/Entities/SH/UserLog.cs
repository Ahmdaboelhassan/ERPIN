using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.SH;

[Table("UserLogs", Schema = "SH")]
public class UserLog
{
    [Key]
    public int Id { get; set; }
    public int Code { get; set; }
    public int UserId { get; set; }
    public int Process { get; set; }
    public int Action { get; set; }
    public DateTime Time { get; set; }
    public string? Notes { get; set; }    
}
