using MediatR;
using SalesApi.Domain.Events;

namespace SalesApi.Application.Sales.Notifications;

public class SaleCancelledNotification : INotification
{
    public SaleCancelledEvent Event { get; }

    public SaleCancelledNotification(SaleCancelledEvent saleCancelledEvent)
    {
        Event = saleCancelledEvent;
    }
}
