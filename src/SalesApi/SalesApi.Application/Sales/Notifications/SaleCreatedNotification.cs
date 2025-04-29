using MediatR;
using SalesApi.Domain.Events;

namespace SalesApi.Application.Sales.Notifications;
public class SaleCreatedNotification : INotification
{
    public SaleCreatedEvent Event { get; }

    public SaleCreatedNotification(SaleCreatedEvent domainEvent)
    {
        Event = domainEvent;
    }
}
