using MediatR;
using SalesApi.Application.Common;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Sales.Queries;

public class GetAllSalesQuery : IRequest<HandlerResult<IEnumerable<Sale>>>
{
}
