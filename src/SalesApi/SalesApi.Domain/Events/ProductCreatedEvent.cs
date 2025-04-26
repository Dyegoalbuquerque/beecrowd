namespace SalesApi.Domain.Events;

public class ProductCreatedEvent
{   
    public ProductCreatedEvent(Guid productId, string name, DateTime createdAt)
    {
        ProductId = productId;
        Name = name;
        CreatedAt = createdAt;
    }
    public Guid ProductId { get; }
    public string Name { get; }
    public DateTime CreatedAt { get; }
}
