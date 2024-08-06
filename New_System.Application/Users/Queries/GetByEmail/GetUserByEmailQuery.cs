using New_System.Application.Core.Messaging;
using New_System.Domain.Users;

namespace New_System.Application.Users.Queries.GetByEmail;

public sealed record GetUserByEmailQuery(string Email) : IQuery<User>;
