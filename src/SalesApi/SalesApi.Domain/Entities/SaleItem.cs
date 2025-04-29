using SalesApi.Domain.Services.Tax;

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
        get => IVAFactory.CreateTax(Quantity).CalculateTax(Quantity * UnitPrice);
    }
    public decimal Total
    {
        get => Quantity * UnitPrice + (ValueMonetaryTaxApplied);
        set { }
    }

    public decimal TotalWithoutTax
    {
        get => Quantity * UnitPrice;
        set { }
    }
}
