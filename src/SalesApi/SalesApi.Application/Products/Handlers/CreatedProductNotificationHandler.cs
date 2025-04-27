using MediatR;
using Microsoft.Extensions.Logging;
using SalesApi.Application.Products.Notifications;

namespace SalesApi.Application.Products.Handlers;

public class ProductCreatedNotificationHandler : INotificationHandler<ProductCreatedNotification>
{
    private readonly ILogger<ProductCreatedNotificationHandler> _logger;

    public ProductCreatedNotificationHandler(ILogger<ProductCreatedNotificationHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("🛒 [Event] ProductCreated - ProductId: {ProductId}, Name: {Name}, CreatedAt: {CreatedAt}",
            notification.Event.ProductId, notification.Event.Name, notification.Event.CreatedAt);

        return Task.CompletedTask;
    }
}
