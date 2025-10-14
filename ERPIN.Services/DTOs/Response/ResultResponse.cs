namespace ERPIN.Services.DTOs.Response;
public record ResultResponse<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public IEnumerable<string> Messages { get; set; }
    public T? Data { get; set; }

}
