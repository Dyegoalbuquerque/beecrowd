using FluentValidation;
using SalesApi.Application.Products.Commands;

namespace SalesApi.Application.Products.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(product => product.Name).NotEmpty().Length(3, 50).WithMessage("Name is required and must be between 3 and 50 characters.");
            RuleFor(product => product.Description).NotEmpty().Length(1, 50).WithMessage("Description is required and must be between 1 and 50 characters.");
            RuleFor(product => product.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(product => product.Stock).GreaterThanOrEqualTo(0).WithMessage("Stock must be zero or more.");
        }
    }
}