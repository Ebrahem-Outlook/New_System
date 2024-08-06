namespace New_System.Domain.Core.Events;

public abstract record DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
        Id = Guid.NewGuid();
        OcurredOn = DateTime.UtcNow;
    }

    public Guid Id { get; }

    public DateTime OcurredOn { get; }
}
