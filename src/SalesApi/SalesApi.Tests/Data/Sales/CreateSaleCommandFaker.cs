using Bogus;
using SalesApi.Application.Sales.Commands;

namespace SalesApi.Tests.Data.Sales;
public static class CreateSaleCommandFaker
{
    public static Faker<CreateSaleCommand> GetCommandFaker(int numberOfItems)
    {
        var commandFaker = new Faker<CreateSaleCommand>()
            .RuleFor(c => c.CustomerId, f => Guid.NewGuid().ToString())
            .RuleFor(c => c.CustomerName, f => f.Name.FullName())
            .RuleFor(c => c.Branch, f => f.Company.CompanyName())
            .RuleFor(s => s.Items, f => Enumerable.Range(0, numberOfItems).Select(_ => GetCreateSaleItemCommandFaker().Generate()).ToList());

        return commandFaker;
    }

    public static Faker<CreateSaleItemCommand> GetCreateSaleItemCommandFaker()
    {
        var saleItemFaker = new Faker<CreateSaleItemCommand>()
            .RuleFor(i => i.ProductId, f => Guid.NewGuid().ToString())
            .RuleFor(i => i.ProductName, f => f.Commerce.ProductName())
            .RuleFor(i => i.Quantity, f => f.Random.Int(1, 25))
            .RuleFor(i => i.UnitPrice, f => f.Finance.Amount(10, 100));

        return saleItemFaker;
    }
}
