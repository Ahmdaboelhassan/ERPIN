using ERPIN.Services.DTOs.Request;
using ERPIN.Services.DTOs.Response;

namespace ERPIN.Services.IServices.Auth;
public interface IAuthService
{
    public Task<ResultResponse<AuthResponse>> Login(LoginReq model);
    public Task<ResultResponse<AuthResponse>> Register(LoginReq model);
    public Task<AuthResponse> RefreshToken(string? token);
}
