namespace SalesApi.Domain.Events;

public class SaleCancelledEvent
{
    public SaleCancelledEvent(Guid saleId, DateTime cancelledAt)
    {
        SaleId = saleId;
        CancelledAt = cancelledAt;
    }
    public Guid SaleId { get; }
    public DateTime CancelledAt { get; }
}
