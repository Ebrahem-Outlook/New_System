using FluentValidation;

namespace New_System.Application.Users.Commands.UpdateUser;

internal sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(user => user.UserId).NotNull().NotEmpty().WithMessage("User Id can't be null or empty.");

        RuleFor(user => user.FirstName).NotNull().NotEmpty().WithMessage("First Name can't be null or empty.");

        RuleFor(user => user.LastName).NotNull().NotEmpty().WithMessage("Last Name can't be null or empty.");
    }
}
