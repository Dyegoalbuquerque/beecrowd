using MediatR;
using Microsoft.Extensions.Logging;
using SalesApi.Application.Sales.Notifications;

namespace SalesApi.Application.Sales.Handlers;

public class CreatedSaleNotificationHandler : INotificationHandler<SaleCreatedNotification>
{
    private readonly ILogger<CreatedSaleNotificationHandler> _logger;

    public CreatedSaleNotificationHandler(ILogger<CreatedSaleNotificationHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SaleCreatedNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("[Event] SaleCreated - SaleId: {SaleId}, CreatedAt: {CreatedAt}",
            notification.Event.SaleId, notification.Event.CreatedAt);

        return Task.CompletedTask;
    }
}
