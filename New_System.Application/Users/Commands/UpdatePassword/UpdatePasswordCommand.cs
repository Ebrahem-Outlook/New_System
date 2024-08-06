using New_System.Application.Core.Messaging;

namespace New_System.Application.Users.Commands.UpdatePassword;

public sealed record UpdatePasswordCommand(Guid UserId, string Email, string Password) : ICommand;
