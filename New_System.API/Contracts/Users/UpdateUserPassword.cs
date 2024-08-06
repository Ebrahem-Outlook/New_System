namespace New_System.API.Contracts.Users;

public sealed record UpdatePasswordRequest(Guid UserId, string Email, string Password);
