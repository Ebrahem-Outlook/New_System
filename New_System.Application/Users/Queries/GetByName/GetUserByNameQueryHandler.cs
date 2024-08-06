using New_System.Application.Core.Messaging;
using New_System.Domain.Users;

namespace New_System.Application.Users.Queries.GetByName;

internal sealed class GetUserByNameQueryHandler : IQueryHandler<GetUserByNameQuery, List<User>>
{
    private readonly IUserRepository _userRepository;

    public GetUserByNameQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByNameAsync(request.Name, cancellationToken);
    }
}
