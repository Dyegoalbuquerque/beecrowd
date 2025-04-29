using MediatR;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Repositories;
using SalesApi.Application.Sales.Queries;
using SalesApi.Application.Common;

namespace SalesApi.Application.Sales.Handlers;

public class GetAllSalesQueryHandler : IRequestHandler<GetAllSalesQuery, HandlerResult<IEnumerable<Sale>>> 
{
    private readonly ISaleRepository _saleRepository;

    public GetAllSalesQueryHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<HandlerResult<IEnumerable<Sale>>> Handle(GetAllSalesQuery request, CancellationToken cancellationToken)
    {
        var sales = await _saleRepository.GetAllAsync();
         return new HandlerResult<IEnumerable<Sale>>(true, "Sales retrieved successfully.", sales);
    }
}
