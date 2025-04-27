using MediatR;
using SalesApi.Domain.Repositories;
using SalesApi.Application.Sales.Notifications;
using SalesApi.Domain.Events;
using SalesApi.Application.Common;
using SalesApi.Application.Sales.Commands;

namespace SalesApi.Application.Sales.Handlers;

public class CancelSaleCommandHandler : IRequestHandler<CancelSaleCommand, HandlerResult<bool>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMediator _mediator;

    public CancelSaleCommandHandler(ISaleRepository saleRepository, IMediator mediator)
    {
        _saleRepository = saleRepository;
        _mediator = mediator;
    }

    public async Task<HandlerResult<bool>> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.Id);
        if (sale == null)
        {
            return new HandlerResult<bool>(false, "Sale not found.", false);
        }
        
        sale.Cancel();

        await _saleRepository.UpdateAsync(sale);
        await _mediator.Publish(new SaleCancelledNotification(new SaleCancelledEvent(sale.Id, DateTime.UtcNow)));

        return new HandlerResult<bool>(true, "Sale canceled successfully.");
    }
}
