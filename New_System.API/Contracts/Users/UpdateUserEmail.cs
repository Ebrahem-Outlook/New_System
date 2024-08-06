namespace New_System.API.Contracts.Users;

public sealed record UpdateEmailRequest(Guid UserId, string Email);
