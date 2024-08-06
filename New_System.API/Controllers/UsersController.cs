using MediatR;
using Microsoft.AspNetCore.Mvc;
using New_System.API.Contracts.Users;
using New_System.Application.Users.Commands.CreateUser;
using New_System.Domain.Users.Events;

namespace New_System.API.Controllers;

[Route("api/v1/[Controller]")]
public sealed class UsersController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request) =>
        Ok(await sender.Send(
            new CreateUserCommand(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password)));

}
