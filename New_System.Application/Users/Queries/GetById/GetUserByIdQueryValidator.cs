using FluentValidation;

namespace New_System.Application.Users.Queries.GetById;

internal sealed class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(user => user.UserId).NotNull().NotEmpty().WithMessage("User Id can't be null or empty.");
    }
}
