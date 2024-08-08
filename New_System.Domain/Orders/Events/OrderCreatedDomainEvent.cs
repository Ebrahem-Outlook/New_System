using New_System.Domain.Core.Events;

namespace New_System.Domain.Orders.Events;

public sealed record OrderCreatedDomainEvent(Order Order) : DomainEvent();
