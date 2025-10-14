namespace ERPIN.Domain.DTOs.Repsonse;
public record RefreshTokenResponse
{
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpireOn { get; set; }


}
