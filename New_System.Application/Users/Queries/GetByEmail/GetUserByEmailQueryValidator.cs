using FluentValidation;

namespace New_System.Application.Users.Queries.GetByEmail;

internal sealed class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
{
    public GetUserByEmailQueryValidator()
    {
        RuleFor(user => user.Email).NotEmpty().NotNull().WithMessage("Email of user can't be null or empty.");
    }
}
