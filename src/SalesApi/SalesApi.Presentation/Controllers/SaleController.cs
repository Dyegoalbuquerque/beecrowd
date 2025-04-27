using Microsoft.AspNetCore.Mvc;
using MediatR;
using SalesApi.Application.Sales.Commands;
using SalesApi.Application.Sales.Queries;

namespace SalesApi.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaleController : ControllerBase
{
    private readonly IMediator _mediator;

    public SaleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSales()
    {
        var result = await _mediator.Send(new GetAllSalesQuery());
        return Ok(new { data = result.Data, status = "success", message = "Sales retrieved successfully" });
    }


    [HttpPost]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleCommand command)
    {

        var result = await _mediator.Send(command);
        if (!result.Success)
        {
            return BadRequest(new { data = result.Errors, status = "fail", message = "Sale creation failed" });
        }

        return CreatedAtAction(nameof(CreateSale), new { id = result.Data.Id }, new
        {
            data = result.Data,
            status = "success",
            message = "Sale created successfully"
        });
    }


    [HttpPatch("{id}")]
    public async Task<IActionResult> CancelSale(Guid id)
    {
        var result = await _mediator.Send(new CancelSaleCommand { Id = id });
        if (!result.Success)
        {
            return NotFound(new { data = result.Errors, status = "fail", message = "Sale cancellation failed" });
        }

        return Ok(new { data = result.Success, status = "success", message = "Sale cancellation successfully" });
    }
}
