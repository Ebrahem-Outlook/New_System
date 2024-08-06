namespace New_System.API.Contracts.Users;

public sealed record UpdateUserRequest(Guid UserId, string FirstName, string LastName);
