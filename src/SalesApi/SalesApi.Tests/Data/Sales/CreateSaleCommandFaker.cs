using Bogus;
using SalesApi.Application.Sales.Commands;

namespace SalesApi.Tests.Data.Sales;
public static class CreateSaleCommandFaker
{
    public static Faker<CreateSaleCommand> GetCommandFaker(int numberOfItems)
    {
        var commandFaker = new Faker<CreateSaleCommand>()
            .RuleFor(c => c.SaleNumber, f => f.Random.Long(1, 25).ToString())
            .RuleFor(c => c.CustomerId, f => Guid.NewGuid().ToString())
            .RuleFor(c => c.SaleDate, f => f.Date.Recent(30))
            .RuleFor(c => c.BranchId, f => Guid.NewGuid().ToString())
            .RuleFor(s => s.Items, f => Enumerable.Range(0, numberOfItems).Select(_ => GetCreateSaleItemCommandFaker().Generate()).ToList());

        return commandFaker;
    }

    public static Faker<CreateSaleItemCommand> GetCreateSaleItemCommandFaker()
    {
        var saleItemFaker = new Faker<CreateSaleItemCommand>()
            .RuleFor(i => i.ProductId, f => Guid.NewGuid().ToString())
            .RuleFor(i => i.Quantity, f => f.Random.Int(1, 25))
            .RuleFor(i => i.UnitPrice, f => f.Finance.Amount(10, 100));

        return saleItemFaker;
    }
}
