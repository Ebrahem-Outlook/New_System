using MediatR;
using New_System.Application.Core.Messaging;

namespace New_System.Application.Users.Commands.DeleteUser;

public sealed record DeleteUserCommand(Guid UserId) : ICommand<Unit>;
