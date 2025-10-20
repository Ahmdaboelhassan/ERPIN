using Asp.Versioning;
using ERPIN.Services.DTOs.Request;
using ERPIN.Services.Services.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERPIN.Controllers.v1;

[ApiController]
[ApiVersion(1)]
[Authorize]
[Route("api/v{version:apiVersion}/[controller]")]
public class SLInvoiceController : ControllerBase
{
    private readonly ISLInvoiceService _invoiceService;

    public SLInvoiceController(ISLInvoiceService invoiceService)
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

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(DateTime from , DateTime to)
    {
        var result = await _invoiceService.GetAll(from, to);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateSLInvoice model)
    {
        var result = await _invoiceService.CreateInvoice(model);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut("Edit")]
    public async Task<IActionResult> Edit(CreateSLInvoice model)
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
