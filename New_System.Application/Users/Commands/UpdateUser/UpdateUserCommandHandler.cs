using MediatR;
using New_System.Application.Core.Data;
using New_System.Application.Core.Messaging;
using New_System.Domain.Users;
using New_System.Domain.Users.ValueObjects;

namespace New_System.Application.Users.Commands.UpdateUser;

internal sealed class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return Unit.Value;
        }

        FirstName firstName = FirstName.Create(request.FirstName);
        LastName lastName = LastName.Create(request.LastName);

        user.UpdateUser(firstName, lastName);

        await _userRepository.UpdateAsync(user, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
