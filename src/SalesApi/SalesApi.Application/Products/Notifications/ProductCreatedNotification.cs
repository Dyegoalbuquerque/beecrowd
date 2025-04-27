using MediatR;
using SalesApi.Domain.Events;

namespace SalesApi.Application.Products.Notifications;

public class ProductCreatedNotification : INotification
{
    public ProductCreatedEvent Event { get; }

    public ProductCreatedNotification(ProductCreatedEvent domainEvent)
    {
        Event = domainEvent;
    }
}
