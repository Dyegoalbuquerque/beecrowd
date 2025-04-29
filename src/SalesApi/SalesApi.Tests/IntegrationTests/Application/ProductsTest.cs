using NSubstitute;
using MediatR;
using AutoMapper;
using FluentValidation;
using SalesApi.Application.Products.Commands;
using SalesApi.Application.Products.Handlers;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Repositories;
using SalesApi.Tests.Data.Products;
using SalesApi.Application.Products.Notifications;
using Xunit;

namespace SalesApi.Tests.IntegrationTests.Application;

public class ProductsTest
{
    [Fact(DisplayName = "Product command handler should create product successfully")]
    public async Task CreateProductCommandHandler_Should_Create_Product_Successfully()
    {
        var productRepository = Substitute.For<IProductRepository>();
        var mediator = Substitute.For<IMediator>();
        var mapper = Substitute.For<IMapper>();
        var validator = Substitute.For<IValidator<CreateProductCommand>>();

        var command = CreateProductCommandFaker.GenerateFakeCreateProductCommand().Generate();

        validator
            .ValidateAsync(command, Arg.Any<CancellationToken>())
            .Returns(new FluentValidation.Results.ValidationResult());

        mapper
            .Map<Product>(command)
            .Returns(new Product());

        var handler = new CreateProductCommandHandler(productRepository, mapper, mediator, validator);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result.Success);
        await productRepository.Received(1).AddAsync(Arg.Any<Product>());
        await mediator.Received(1).Publish(Arg.Any<ProductCreatedNotification>(), Arg.Any<CancellationToken>());
    }
}
