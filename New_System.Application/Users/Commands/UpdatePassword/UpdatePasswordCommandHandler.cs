using MediatR;
using New_System.Application.Core.Data;
using New_System.Application.Core.Messaging;
using New_System.Domain.Users;
using New_System.Domain.Users.ValueObjects;

namespace New_System.Application.Users.Commands.UpdatePassword;

internal sealed class UpdatePasswordCommandHandler : ICommandHandler<UpdatePasswordCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePasswordCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {


        User? user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null || user.Email.Value != request.Email)
        {
            return Unit.Value;
        }

        Password password = Password.Create(request.Password);

        user.UpdatePassword(password);

        await _userRepository.UpdateAsync(user, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
