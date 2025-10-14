using ERPIN.Domain.IRepositories;
using ERPIN.Services.DTOs.Request;
using ERPIN.Services.DTOs.Response;
using ERPIN.Services.IServices.Auth;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IdentityModel.Tokens.Jwt;

namespace ERPIN.Services.Services.Auth;
public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    public AuthService(ITokenService tokenService, IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
    {
        _tokenService = tokenService;
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task<ResultResponse<AuthResponse>> Login(LoginReq model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);

        if (user is null)
            return Result.Error<AuthResponse>("Invalid Username or Password");

        var verify = await _userManager.CheckPasswordAsync(user, model.Password);

        if (!verify)
            return Result.Error<AuthResponse>("Invalid Username or Password");

        var token = _tokenService.CreateToken(user);

        if (token is null)
            return Result.Error<AuthResponse>("Something went wrong while creating token");
        
        var authResponse = new AuthResponse
        {
            Message = "Login Successfully",
            UserName = model.UserName,
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            ExpireOn = token.ValidTo
        };

        // Refresh Token implementation is commented out for now
        //if (model.StayLogin)
        //{
        //    var refreshToken = await _tokenService.CreateRefreshToken(user);
        //    authResponse.RefreshToken = refreshToken.RefreshToken;
        //    authResponse.RefreshTokenExpireOn = refreshToken.RefreshTokenExpireOn;
        //}

        return Result.Success(authResponse);
    }

    public async Task<ResultResponse<AuthResponse>> Register(LoginReq model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);

        if (user is not null)
            return Result.Error<AuthResponse>("Invalid Username");


        var newUser = new IdentityUser
        {
           UserName = model.UserName,
        };

        var createUser = await _userManager.CreateAsync(newUser, model.Password);
        if (!createUser.Succeeded)
            return Result.Error<AuthResponse>(createUser.Errors.First());


        var token = _tokenService.CreateToken(newUser);

        if (token is null)
            return Result.Error<AuthResponse>("Something went wrong while creating token");


        var authResponse = new AuthResponse
        {
            Message = "User Created Successfully",
            UserName = model.UserName,
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            ExpireOn = token.ValidTo
        };


        //if (model.StayLogin)
        //{
        //    var refreshToken = await _tokenService.CreateRefreshToken(user);
        //    authResponse.RefreshToken = refreshToken.RefreshToken;
        //    authResponse.RefreshTokenExpireOn = refreshToken.RefreshTokenExpireOn;
        //}

        return Result.Success(authResponse);
    }

    public Task<AuthResponse> RefreshToken(string? token)
    {
        ////if (string.IsNullOrEmpty(token))
        ////    return new AuthResponse() {Message = "Invalid Token" };

        ////var refreshToken = await _unitOfWork.RefreshTokens.Get(rt => rt.Token == token && !rt.IsRevoked, "User");
        ////if (refreshToken is null)
        ////    return new AuthResponse() {Message = "Invalid Refresh Token" };

        ////if (refreshToken.ExpireOn < DateTime.UtcNow)
        ////    return new AuthResponse() {Message = "Refresh Token Expired" };

        ////var user = refreshToken.User;

        ////var newToken = _tokenService.CreateToken(user);

        ////if (newToken is null)
        ////    return new AuthResponse() { IsAuth = false, Message = "Something went wrong while creating token" };

        ////var authResponse = new AuthResponse
        ////{
        ////    IsAuth = true,
        ////    Message = "Login Successfully",
        ////    UserName = user.Username,
        ////    ExpireOn = newToken.ValidTo,
        ////    Token = new JwtSecurityTokenHandler().WriteToken(newToken),
        ////};

        ////if (refreshToken.ExpireOn < DateTime.UtcNow.AddDays(10))
        ////{
        ////    // delete old refresh token
        ////    _unitOfWork.RefreshTokens.Delete(refreshToken);
        ////    await _unitOfWork.SaveChangesAync();

        ////    // create new refresh token
        ////    var newRefreshToken = await _tokenService.CreateRefreshToken(user);
        ////    authResponse.RefreshToken = newRefreshToken.RefreshToken;
        ////    authResponse.RefreshTokenExpireOn = newRefreshToken.RefreshTokenExpireOn;
        ////}
        ////else
        ////{
        ////    authResponse.RefreshToken = refreshToken.Token;
        ////    authResponse.RefreshTokenExpireOn = refreshToken.ExpireOn;
        ////}

        //return authResponse;
        throw new NotImplementedException();
    }
}
