using MediatR;
using New_System.Application.Core.Data;
using New_System.Application.Core.Messaging;
using New_System.Domain.Users;
using New_System.Domain.Users.ValueObjects;

namespace New_System.Application.Users.Commands.UpdateEmail;

internal sealed class UpdateEmailCommandHanlder : ICommandHandler<UpdateEmailCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmailCommandHanlder(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateEmailCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if(user is null)
        {
            return Unit.Value;
        }

        Email email = Email.Create(request.Email);

        user.UpdateEmail(email);

        await _userRepository.UpdateAsync(user, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
