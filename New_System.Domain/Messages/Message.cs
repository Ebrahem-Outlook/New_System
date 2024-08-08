using New_System.Domain.Core.BaseType;
using New_System.Domain.Messages.ValueObjects;

namespace New_System.Domain.Messages;

public sealed class Message : AggregateRoot<MessageId>, IAuditable, ISoftDeletable
{
    public DateTime CreatedDate { get; }

    public DateTime? ModifiedDate { get; private set; }

    public bool IsDeletable { get; private set; }

    public DateTime? DeletedDate { get; }
}
