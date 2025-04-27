using MediatR;
using SalesApi.Application.Common;

namespace SalesApi.Application.Sales.Commands
{
    public class CancelSaleCommand : IRequest<HandlerResult<bool>>
    {
        public Guid Id { get; set; }
    }
}