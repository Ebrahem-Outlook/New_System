using New_System.Domain.Users;

namespace New_System.Application.Core.Abstractions.Authentication;

public interface IJwtProvider
{
    string GenerateToke(User user);
}
