using MediatR;

namespace New_System.Domain.Core.Events;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OcurredOn { get; }
}
