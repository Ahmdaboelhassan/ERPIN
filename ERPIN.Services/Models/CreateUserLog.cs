namespace ERPIN.Services.Models;
public class CreateUserLog
{
    public int Process { get; set; }
    public int Action { get; set; }
    public string? Notes { get; set; }
    public int Code { get; set; }
}
