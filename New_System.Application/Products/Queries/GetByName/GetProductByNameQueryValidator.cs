using FluentValidation;

namespace New_System.Application.Products.Queries.GetByName;

internal sealed class GetProductByNameQueryValidator : AbstractValidator<GetProductByNameQuery>
{
    public GetProductByNameQueryValidator()
    {
        RuleFor(product => product.Name).NotNull().NotEmpty().WithMessage("Name of product can't be null or empty.");
    }
}
