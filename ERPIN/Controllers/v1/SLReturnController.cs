using Asp.Versioning;
using ERPIN.Services.DTOs.Request;
using ERPIN.Services.Services.Sales;
using Microsoft.AspNetCore.Mvc;

namespace ERPIN.Controllers.v1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class SLReturnController : ControllerBase
{
    private readonly ISLReturnService _invoiceService;

    public SLReturnController(ISLReturnService invoiceService)
    {
        _invoiceService = invoiceService;
    }


    [HttpGet("New")]
    public async Task<IActionResult> New()
    {
        var result = await _invoiceService.NewInvoice();
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("Get/{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _invoiceService.GetInvoice(id);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateSLReturn model)
    {
        var result = await _invoiceService.CreateInvoice(model);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut("Edit")]
    public async Task<IActionResult> Edit(CreateSLReturn model)
    {
        var result = await _invoiceService.EditInvoice(model);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _invoiceService.DeleteInvoice(id);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }
}
