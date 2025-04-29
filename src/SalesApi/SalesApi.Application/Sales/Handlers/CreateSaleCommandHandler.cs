using MediatR;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Events;
using SalesApi.Domain.Repositories;
using SalesApi.Application.Sales.Commands;
using AutoMapper;
using FluentValidation;
using SalesApi.Application.Common;
using SalesApi.Application.Sales.Notifications;

namespace SalesApi.Application.Sales.Handlers;

public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, HandlerResult<Sale>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IValidator<CreateSaleCommand> _validator;

    public CreateSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper, IMediator mediator, IValidator<CreateSaleCommand> validator)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _mediator = mediator;
        _validator = validator;
    }

    public async Task<HandlerResult<Sale>> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return new HandlerResult<Sale>(false, string.Empty, null, validationResult.Errors);
        }

        var sale = _mapper.Map<Sale>(request);
        
        sale.CalculateSale();        

        await _saleRepository.AddAsync(sale);
        await _mediator.Publish(new SaleCreatedNotification(new SaleCreatedEvent(sale.Id, DateTime.UtcNow)));

        return new HandlerResult<Sale>(true, string.Empty, sale);
    }
}
