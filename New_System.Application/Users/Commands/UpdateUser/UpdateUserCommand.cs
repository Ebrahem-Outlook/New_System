using MediatR;
using New_System.Application.Core.Messaging;

namespace New_System.Application.Users.Commands.UpdateUser;

public sealed record UpdateUserCommand(Guid UserId, string FirstName, string LastName) : ICommand<Unit>;
