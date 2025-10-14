namespace ERPIN.Services.DTOs.Response;
public record RefreshTokenResponse
{
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpireOn { get; set; }


}
