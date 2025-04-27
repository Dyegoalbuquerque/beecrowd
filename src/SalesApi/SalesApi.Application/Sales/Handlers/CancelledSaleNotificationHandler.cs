using MediatR;
using Microsoft.Extensions.Logging;
using SalesApi.Application.Sales.Notifications;

namespace SalesApi.Application.Sales.Handlers;

public class CancelledSaleNotificationHandler : INotificationHandler<SaleCancelledNotification>
{
    private readonly ILogger<CancelledSaleNotificationHandler> _logger;

    public CancelledSaleNotificationHandler(ILogger<CancelledSaleNotificationHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SaleCancelledNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("[Event] SaleCancelled - SaleId: {SaleId}, CancelledAt: {CancelledAt}",
            notification.Event.SaleId, notification.Event.CancelledAt);

        return Task.CompletedTask;
    }
}
