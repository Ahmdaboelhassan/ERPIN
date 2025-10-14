namespace ERPIN.Domain.DTOs.Repsonse;
public static class Result
{
    public static ResultResponse<T> Error<T>(string message)
    {
        return new ResultResponse<T>
        {
            IsSuccess = false,
            Message = message
        };
    }

    public static ResultResponse<T> Errors<T>(IEnumerable<string> messages)
    {
        return new ResultResponse<T>
        {
            IsSuccess = false,
            Messages = messages
        };
    }

    public static ResultResponse<T> Success<T>(T data, string message = "")
    {
        return new ResultResponse<T>
        {
            IsSuccess = true,
            Data = data,
            Message = message
        };
    }
}
