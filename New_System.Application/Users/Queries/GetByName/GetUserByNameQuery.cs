using New_System.Application.Core.Messaging;
using New_System.Domain.Users;

namespace New_System.Application.Users.Queries.GetByName;

public sealed record GetUserByNameQuery(string Name) : IQuery<List<User>>;
