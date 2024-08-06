using New_System.Application.Core.Messaging;
using New_System.Domain.Users;

namespace New_System.Application.Users.Queries.GetById;

public sealed record GetUserByIdQuery(Guid UserId) : IQuery<User>;

