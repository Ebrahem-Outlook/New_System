using New_System.Application.Core.Messaging;
using New_System.Domain.Users;

namespace New_System.Application.Users.Queries.GetAll;

public sealed record GetAllUsersQuery() : IQuery<List<User>>;
