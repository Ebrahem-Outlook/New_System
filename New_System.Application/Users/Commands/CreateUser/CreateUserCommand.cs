using MediatR;
using New_System.Application.Core.Messaging;

namespace New_System.Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(
    string FirstName, 
    string LastName, 
    string Email, 
    string Password) : ICommand<Unit>;
