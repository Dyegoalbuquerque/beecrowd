namespace SalesApi.Domain.Entities;

public class SaleItem
{
    public SaleItem()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal ValueMonetaryTaxApplied
    {
        get => Quantity switch
        {
            >= 10 and <= 20 => 20m, // IVA Special
            > 4 and < 10 => 10m,    // IVA Normal
            _ => 0m                 // Free of IVA
        };
    }
    public decimal Total
    {
        get => Quantity * UnitPrice + (Quantity * UnitPrice * (ValueMonetaryTaxApplied / 100));
        set { }
    }
}
