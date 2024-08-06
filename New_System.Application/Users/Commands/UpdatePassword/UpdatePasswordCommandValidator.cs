using FluentValidation;

namespace New_System.Application.Users.Commands.UpdatePassword;

internal sealed class UpdatePasswordCommandValidator : AbstractValidator<UpdatePasswordCommand>
{
    public UpdatePasswordCommandValidator()
    {
        RuleFor(user => user.UserId).NotNull().NotEmpty().WithMessage("User Id can't be null or empty.");

        RuleFor(user => user.Email).NotNull().NotEmpty().WithMessage("User Id can't be null or empty.");

        RuleFor(user => user.Password).NotNull().NotEmpty().WithMessage("User Id can't be null or empty.");
    }
}
