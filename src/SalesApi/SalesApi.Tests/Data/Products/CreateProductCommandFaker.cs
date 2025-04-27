using Bogus;
using SalesApi.Application.Products.Commands;

namespace SalesApi.Tests.Data.Products;
public static class CreateProductCommandFaker
{
    public static Faker<CreateProductCommand> GenerateFakeCreateProductCommand()
    {
        var commandFaker = new Faker<CreateProductCommand>()
            .RuleFor(c => c.Name, f => Guid.NewGuid().ToString())
            .RuleFor(c => c.Description, f => f.Commerce.ProductName())
            .RuleFor(c => c.Price, f => f.Random.Decimal(10, 1000))
            .RuleFor(c => c.Stock, f => f.Random.Int(1, 100));
        return commandFaker;
    }
}