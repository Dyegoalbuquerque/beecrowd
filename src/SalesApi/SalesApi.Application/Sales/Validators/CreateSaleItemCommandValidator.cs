using FluentValidation;

namespace SalesApi.Application.Sales.Validators;

public class CreateSaleItemCommandValidator : AbstractValidator<CreateSaleItemCommand>
{
    public CreateSaleItemCommandValidator()
    {
        RuleFor(item => item.ProductId)
            .NotEmpty().WithMessage("Product ID is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Product ID must be a valid GUID.");

        RuleFor(item => item.ProductName)
            .NotEmpty().Length(3, 100).WithMessage("Product name is required and must be between 3 and 100 characters.");

        RuleFor(item => item.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

        RuleFor(item => item.UnitPrice)
            .GreaterThan(0).WithMessage("Unit price must be greater than 0.");
    }
}
