using MediatR;
using Microsoft.AspNetCore.Mvc;
using New_System.API.Contracts.Users;
using New_System.Application.Users.Commands.CreateUser;
using New_System.Application.Users.Commands.UpdateEmail;
using New_System.Application.Users.Commands.UpdatePassword;
using New_System.Application.Users.Commands.UpdateUser;
using New_System.Application.Users.Queries.GetAll;
using New_System.Application.Users.Queries.GetByEmail;
using New_System.Application.Users.Queries.GetById;
using New_System.Application.Users.Queries.GetByName;

namespace New_System.API.Controllers;

[Route("api/v1/[Controller]")]
public sealed class UsersController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request) =>
        Ok(await sender.Send(
            new CreateUserCommand(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password)));

    [HttpPut("user")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request) =>
        Ok(await sender.Send(
            new UpdateUserCommand(
                request.UserId,
                request.FirstName,
                request.LastName)));

    [HttpPut("email")]
    public async Task<IActionResult> UpdateEmail([FromBody] UpdateEmailRequest request) =>
        Ok(await sender.Send(
            new UpdateEmailCommand(
                request.UserId,
                request.Email)));

    [HttpPut("password")]
    public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequest request) =>
        Ok(await sender.Send(
            new UpdatePasswordCommand(
                request.UserId,
                request.Email,
                request.Password)));

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await sender.Send(new GetAllUsersQuery()));

    [HttpGet("id")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await sender.Send(new GetUserByIdQuery(id)));

    [HttpGet("email")]
    public async Task<IActionResult> GetByEmail(string email) => Ok(await sender.Send(new GetUserByEmailQuery(email)));

    [HttpGet("name")]
    public async Task<IActionResult> GetByName(string name) => Ok(await sender.Send(new GetUserByNameQuery(name)));
}
