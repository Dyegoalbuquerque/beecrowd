using MediatR;
using SalesApi.Application.Common;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Products.Queries;

public class GetAllProductsQuery : IRequest<HandlerResult<IEnumerable<Product>>>
{
}