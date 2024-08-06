using FluentValidation;

namespace New_System.Application.Users.Commands.CreateUser;

internal sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(user => user.FirstName).NotNull().NotEmpty().WithMessage("First Name can't be null or empty");

        RuleFor(user => user.FirstName).NotNull().NotEmpty().WithMessage("Last Name can't be null or empty");

        RuleFor(user => user.FirstName).NotNull().NotEmpty().WithMessage("Email can't be null or empty");

        RuleFor(user => user.FirstName).NotNull().NotEmpty().WithMessage("Password can't be null or empty");
    }
}
