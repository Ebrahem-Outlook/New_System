using FluentValidation;

namespace New_System.Application.Users.Commands.UpdateEmail;

internal sealed class UpdateEmailCommandValidator : AbstractValidator<UpdateEmailCommand>
{
    public UpdateEmailCommandValidator()
    {
        RuleFor(user => user.UserId).NotNull().NotEmpty().WithMessage("User Id can't be null or empty.");

        RuleFor(user => user.Email).NotNull().NotEmpty().WithMessage("Email can't be null or empty.");
    }
}
