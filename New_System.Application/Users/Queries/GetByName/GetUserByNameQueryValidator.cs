using FluentValidation;

namespace New_System.Application.Users.Queries.GetByName;

internal sealed class GetUserByNameQueryValidator : AbstractValidator<GetUserByNameQuery>
{
    public GetUserByNameQueryValidator()
    {
        RuleFor(user => user.Name).NotEmpty().NotNull().WithMessage("User Name can't be null or empty.");
    }
}
