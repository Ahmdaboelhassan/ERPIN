using ERPIN.Services.DTOs.Response;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IdentityModel.Tokens.Jwt;

namespace ERPIN.Services.IServices.Auth;
public interface ITokenService
{
    JwtSecurityToken? CreateToken(IdentityUser user);
    Task<RefreshTokenResponse> CreateRefreshToken(IdentityUser user);
}
