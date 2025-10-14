namespace ERPIN.Domain.DTOs.Request;

public record RefreshTokenRequest
{
    public required string RefreshToken { get; set; }
}
