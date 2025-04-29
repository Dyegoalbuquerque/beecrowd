using MediatR;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Repositories;
using SalesApi.Application.Products.Queries;
using SalesApi.Application.Common;

namespace SalesApi.Application.Products.Handlers;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, HandlerResult<IEnumerable<Product>>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<HandlerResult<IEnumerable<Product>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();

        return new HandlerResult<IEnumerable<Product>>(true, "Products retrieved successfully.", products);
    }
}
