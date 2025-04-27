using Bogus;
using SalesApi.Domain.Entities;

namespace SalesApi.Tests.Data.Sales;
public static class SaleFaker
{
    public static Faker<Sale> GetSaleFaker(int numberOfItems)
    {
        var saleFaker = new Faker<Sale>()
            .RuleFor(s => s.Id, f => Guid.NewGuid())
            .RuleFor(s => s.Nummber, f => $"S-{DateTime.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid().ToString()[..8]}")
            .RuleFor(s => s.CustomerId, f => Guid.NewGuid())
            .RuleFor(s => s.CustomerName, f => f.Name.FullName())
            .RuleFor(s => s.Date, f => f.Date.Recent(30)) 
            .RuleFor(s => s.Branch, f => f.Company.CompanyName())
            .RuleFor(s => s.IsCancelled, f => f.Random.Bool(0.1f)) 
            .RuleFor(s => s.Items, f => Enumerable.Range(0, numberOfItems).Select(_ => GetSaleItemFaker().Generate()).ToList()); // Número de itens especificado

        return saleFaker;
    }

    public static Faker<SaleItem> GetSaleItemFaker()
    {
        var saleItemFaker = new Faker<SaleItem>()
            .RuleFor(i => i.Id, f => Guid.NewGuid())
            .RuleFor(i => i.ProductId, f => Guid.NewGuid())
            .RuleFor(i => i.ProductName, f => f.Commerce.ProductName())
            .RuleFor(i => i.Quantity, f => f.Random.Int(1, 25))
            .RuleFor(i => i.UnitPrice, f => f.Finance.Amount(10, 100));

        return saleItemFaker;
    }
}
