using MediatR;
using New_System.Application.Core.Data;
using New_System.Application.Core.Messaging;
using New_System.Domain.Users;
using New_System.Domain.Users.ValueObjects;
using System.Runtime.Serialization;

namespace New_System.Application.Users.Commands.CreateUser;

internal sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        FirstName firstName = FirstName.Create(request.FirstName); 
        LastName lastName = LastName.Create(request.LastName); 
        Email email= Email.Create(request.Email); 
        Password password = Password.Create(request.Password);

        User user = User.Create(firstName, lastName, email, password);

        await _userRepository.AddAsync(user, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
