using Microsoft.AspNetCore.Mvc;
using MediatR;
using SalesApi.Application.Products.Queries;
using SalesApi.Application.Products.Commands;

namespace SalesApi.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var result = await _mediator.Send(new GetAllProductsQuery());

        return Ok(new
        {
            data = result.Data,
            status = "success",
            message = "Operation completed successfully"
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.Success)
        {
            return BadRequest(new { data = result.Errors, status = "fail", message = "Product creation failed" });
        }
        
        return CreatedAtAction(nameof(GetAllProducts), new { id = result.Data.Id }, new
        {
            data = result.Data,
            status = "success",
            message = "Product created successfully"
        });
    }
}