using MediatR;
using AutoMapper;
using FluentValidation;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Events;
using SalesApi.Domain.Repositories;
using SalesApi.Application.Products.Notifications;
using SalesApi.Application.Products.Commands;
using SalesApi.Application.Common;

namespace SalesApi.Application.Products.Handlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, HandlerResult<Product>>
{
    private readonly IMediator _mediator;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateProductCommand> _validator;

    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IMediator mediator, IValidator<CreateProductCommand> validator)
    {
        _productRepository = productRepository;
        _mediator = mediator;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<HandlerResult<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return new HandlerResult<Product>(false, string.Empty, null, validationResult.Errors);
        }

        var product = _mapper.Map<Product>(request);

        await _productRepository.AddAsync(product);
        await _mediator.Publish(new ProductCreatedNotification(new ProductCreatedEvent(product.Id, product.Description, DateTime.UtcNow)));

        return new HandlerResult<Product>(true, "Product created successfully.", product);
    }
}
