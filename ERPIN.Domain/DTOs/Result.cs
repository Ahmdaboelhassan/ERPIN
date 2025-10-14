namespace ERPIN.Domain.DTOs;
public record Result<T>
{
    public bool IsSuccess { get; set; }
    public List<string> WarningMessages { get; set; }
    public List<string> ErrorMessages { get; set; }
    public List<string> InfoMessages { get; set; }
    public T? Data { get; set; }
}
