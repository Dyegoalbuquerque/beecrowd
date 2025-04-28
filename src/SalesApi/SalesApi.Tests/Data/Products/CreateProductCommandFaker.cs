using Bogus;
using SalesApi.Application.Products.Commands;

namespace SalesApi.Tests.Data.Products;
public static class CreateProductCommandFaker
{
    public static Faker<CreateProductCommand> GenerateFakeCreateProductCommand()
    {
        var commandFaker = new Faker<CreateProductCommand>()
            .RuleFor(c => c.Category, f => f.Commerce.Categories(1).First())
            .RuleFor(c => c.Description, f => f.Commerce.ProductDescription())
            .RuleFor(c => c.Price, f => f.Finance.Amount(10, 1000, 2)) 
            .RuleFor(c => c.Image, f => f.Internet.Url());
        return commandFaker;
    }
}