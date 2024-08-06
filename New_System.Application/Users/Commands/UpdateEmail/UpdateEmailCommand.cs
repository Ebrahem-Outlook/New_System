using New_System.Application.Core.Messaging;

namespace New_System.Application.Users.Commands.UpdateEmail;

public sealed record UpdateEmailCommand(Guid UserId, string Email) : ICommand;
