using FluentValidation;

namespace New_System.Application.Users.Commands.DeleteUser;

internal sealed class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(user => user.UserId).NotNull().NotEmpty().WithMessage("User Id can n't be null or empty.");
    }
}
