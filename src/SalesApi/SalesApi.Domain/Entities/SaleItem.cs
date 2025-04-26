using System.Dynamic;

namespace SalesApi.Domain.Entities;

public class SaleItem
{
    public SaleItem()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }    
    public decimal TotalAmount { get => Quantity * UnitPrice; set {} }
}
