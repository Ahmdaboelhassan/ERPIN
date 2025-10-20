using Asp.Versioning;
using ERPIN.Services.Services.INV;
using ERPIN.Services.Services.Sales;
using Microsoft.AspNetCore.Mvc;

namespace ERPIN.Controllers.v1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomersService _customersService;
    public CustomersController(ICustomersService customersService)
    {
        _customersService = customersService;
    }

    [HttpGet]
    [Route("GetAllSelectList")]
    public async Task<IActionResult> GetAllSelectList()
    {
        return Ok(await _customersService.GetAllSelectList());
    }
}
