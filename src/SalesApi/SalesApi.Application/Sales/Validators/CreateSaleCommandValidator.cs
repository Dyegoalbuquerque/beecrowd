using FluentValidation;
using SalesApi.Application.Sales.Commands;

namespace SalesApi.Application.Sales.Validators
{
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleCommandValidator()
        {

            RuleFor(sale => sale.SaleNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("SaleNumber is required.")
                .Matches(@"^[a-zA-Z0-9]*$").WithMessage("SaleNumber must be alphanumeric.")
                .Length(1, 5).WithMessage("SaleNumber must be between 1 and 5 characters.");


            RuleFor(sale => sale.SaleDate)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("SaleDate is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("SaleDate cannot be in the future.");

            RuleFor(sale => sale.BranchId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Branch ID is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Branch ID must be a valid GUID.");

            RuleFor(sale => sale.CustomerId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Customer ID is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Customer ID must be a valid GUID.");


            RuleFor(sale => sale.Items)
                .NotEmpty().WithMessage("Sale must have at least one item.");

            RuleForEach(sale => sale.Items)
                .SetValidator(new CreateSaleItemCommandValidator());

            RuleFor(sale => sale)
                .Must(sale => sale.Items
                             .GroupBy(i => i.ProductId)
                             .Select(g => g.Sum(i => i.Quantity))
                             .DefaultIfEmpty(0).Max() <= 20)
                .When(sale => sale.Items != null && sale.Items.Any())
                .WithMessage("Each product in the sale must not have more than 20 units.");
        }
    }
}
