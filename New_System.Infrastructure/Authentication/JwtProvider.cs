using New_System.Application.Core.Abstractions.Authentication;
using New_System.Domain.Users;

namespace New_System.Infrastructure.Authentication;

internal sealed class JwtProvider : IJwtProvider
{
    public string GenerateToke(User user)
    {
        throw new NotImplementedException();
    }
}
