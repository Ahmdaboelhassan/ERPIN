using Asp.Versioning;
using ERPIN.Services.DTOs.Request;
using ERPIN.Services.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace ERPIN.Controllers.v1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginReq model)
    {
        var result = await _authService.Login(model);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result.Data);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(LoginReq model)
    {
        var result = await _authService.Register(model);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result.Data);
    }
    

}
