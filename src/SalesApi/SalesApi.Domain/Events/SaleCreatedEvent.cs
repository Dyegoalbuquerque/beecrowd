namespace SalesApi.Domain.Events;

public class SaleCreatedEvent
{
    public SaleCreatedEvent(Guid saleId, DateTime createdAt)
    {
        SaleId = saleId;
        CreatedAt = createdAt;
    }
    public Guid SaleId { get; }
    public DateTime CreatedAt { get; }
}
