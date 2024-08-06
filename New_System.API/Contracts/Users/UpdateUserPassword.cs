namespace New_System.API.Contracts.Users;

public sealed record UpdateUserPassword(Guid UserId, string Email, string Password);
