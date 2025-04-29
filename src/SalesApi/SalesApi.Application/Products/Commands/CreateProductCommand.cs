using MediatR;
using SalesApi.Application.Common;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Products.Commands;

public class CreateProductCommand : IRequest<HandlerResult<Product>>
{
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }  
    public string Image { get; set; } = string.Empty;
}