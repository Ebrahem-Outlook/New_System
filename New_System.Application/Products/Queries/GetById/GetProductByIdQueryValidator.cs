using FluentValidation;

namespace New_System.Application.Products.Queries.GetById;

internal sealed class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(product => product.ProductId).NotNull().NotEmpty().WithMessage("Product Id can't be null or empty.");
    }
}
