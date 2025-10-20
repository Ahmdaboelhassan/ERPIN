using Asp.Versioning;
using ERPIN.Services.Services.INV;
using ERPIN.Services.Services.Purchases;
using Microsoft.AspNetCore.Mvc;

namespace ERPIN.Controllers.v1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class VendorsController : ControllerBase
{
    private readonly IVendorsServices _vendorsService;
    public VendorsController(IVendorsServices vendorsService)
    {
        _vendorsService = vendorsService;
    }

    [HttpGet]
    [Route("GetAllSelectList")]
    public async Task<IActionResult> GetAllSelectList()
    {
        return Ok(await _vendorsService.GetAllSelectList());
    }
}
