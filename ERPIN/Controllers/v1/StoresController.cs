using Asp.Versioning;
using ERPIN.Services.Services.INV;
using Microsoft.AspNetCore.Mvc;

namespace ERPIN.Controllers.v1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class StoresController : ControllerBase
{
    private readonly IStoresService _storesService;
    public StoresController(IStoresService storesService)
    {
        _storesService = storesService;
    }

    [HttpGet]
    [Route("GetAllSelectList")]
    public  async Task<IActionResult> GetAllSelectList()
    {
        return Ok( await _storesService.GetAllSelectList());
    }


}
