using FluentValidation;
using SalesApi.Application.Products.Commands;

namespace SalesApi.Application.Products.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(product => product.Category).NotEmpty().Length(3, 150).WithMessage("Category is required and must be between 3 and 150 characters.");
            RuleFor(product => product.Description).NotEmpty().Length(1, 150).WithMessage("Description is required and must be between 1 and 150 characters.");
            RuleFor(product => product.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(product => product.Image).NotEmpty().Length(3, 300).WithMessage("Image is required and must be between 3 and 300 characters.");
        }
    }
}