using New_System.Domain.Core.Events;

namespace New_System.Domain.Core.BaseType;

public abstract class AggregateRoot<TId> : Entity<TId> ,IAggregateRoot
    where TId : class
{
    protected AggregateRoot(TId id) : base(id) { }

    protected AggregateRoot() : base() { }

    private readonly List<IDomainEvent> domainEvents = [];

    public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents.AsReadOnly();

    public void RaiseDomainEvent(IDomainEvent @event) => domainEvents.Add(@event);

    public void ClearDomainEvent() => domainEvents.Clear();
}

public interface IAggregateRoot
{
    public IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    public void RaiseDomainEvent(IDomainEvent @event);

    void ClearDomainEvent();
}