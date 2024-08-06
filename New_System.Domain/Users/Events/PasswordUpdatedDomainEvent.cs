using New_System.Domain.Core.Events;

namespace New_System.Domain.Users.Events;

public sealed record PasswordUpdatedDomainEvent(User User) : DomainEvent();
