using New_System.Domain.Core.Events;

namespace New_System.Domain.Products.Events;

public sealed record ProductCreatedDomainEvent(Product Product) : DomainEvent();
