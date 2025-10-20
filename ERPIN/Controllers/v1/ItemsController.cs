using Asp.Versioning;
using ERPIN.Services.Services.INV;
using ERPIN.Services.Services.Purchases;
using Microsoft.AspNetCore.Mvc;

namespace ERPIN.Controllers.v1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class ItemsController : ControllerBase
{

    private readonly IItemsService _itemsService;
    public ItemsController(IItemsService itemsService)
    {
        _itemsService = itemsService;
    }

    [HttpGet]
    [Route("GetAllSelectList")]
    public async Task<IActionResult> GetAllSelectList()
    {
        return Ok(await _itemsService.GetAllSelectList());
    }

    [HttpGet]
    [Route("GetItemsForInvoice")]
    public async Task<IActionResult> GetItemsForInvoice()
    {
        return Ok(await _itemsService.GetItemsForInvoice());
    }
}
