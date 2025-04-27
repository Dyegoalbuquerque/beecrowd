using NSubstitute;
using MediatR;
using AutoMapper;
using FluentValidation;
using SalesApi.Application.Sales.Commands;
using SalesApi.Application.Sales.Handlers;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Repositories;
using SalesApi.Application.Sales.Notifications;
using SalesApi.Tests.Data.Sales;
using Xunit;

namespace SalesApi.Tests.IntegrationTests.Application;

public class SalesTest
{
    private readonly ISaleRepository saleRepository;
    private readonly IMediator mediator;
    private readonly IMapper mapper;
    private readonly IValidator<CreateSaleCommand> validator;

    public SalesTest()
    {
        saleRepository = Substitute.For<ISaleRepository>();
        mediator = Substitute.For<IMediator>();
        mapper = Substitute.For<IMapper>();
        validator = Substitute.For<IValidator<CreateSaleCommand>>();
    }

    [Fact(DisplayName = "Sale command handler should create sale successfully")]
    public async Task CreateSaleCommandHandler_Should_Create_Sale_Successfully()
    {
        var command = CreateSaleCommandFaker.GetCommandFaker(5).Generate();

        validator
            .ValidateAsync(command, Arg.Any<CancellationToken>())
            .Returns(new FluentValidation.Results.ValidationResult());

        mapper
            .Map<Sale>(command)
            .Returns(new Sale());

        var handler = new CreateSaleCommandHandler(saleRepository, mapper, mediator, validator);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result.Success);
        await saleRepository.Received(1).AddAsync(Arg.Any<Sale>());
        await mediator.Received(1).Publish(Arg.Any<SaleCreatedNotification>(), Arg.Any<CancellationToken>());
    }

    [Fact(DisplayName = "Sale command handler should cancel sale successfully")]
    public async Task DeleteSaleCommandHandler_Should_Cancel_Sale_Successfully()
    {
        var command = new CancelSaleCommand { Id = Guid.NewGuid() };
        var sale = new Sale { Id = command.Id };

        saleRepository
            .GetByIdAsync(command.Id)
            .Returns(sale);

        var handler = new CancelSaleCommandHandler(saleRepository, mediator);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.True(result.Success);
        await saleRepository.Received(1).UpdateAsync(sale);
        await mediator.Received(1).Publish(Arg.Any<SaleCancelledNotification>(), Arg.Any<CancellationToken>());
    }
}
