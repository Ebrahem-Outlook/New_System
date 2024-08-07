using FluentValidation;

namespace New_System.Application.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(product => product.Name).NotNull().NotEmpty().WithMessage("Name of product can't be null or empty.");

        RuleFor(product => product.Description).NotNull().NotEmpty().WithMessage("Description of product can't be null or empty.");

        RuleFor(product => product.Price).NotNull().NotEmpty().WithMessage("Price of product can't be null or empty.");
    }
}
