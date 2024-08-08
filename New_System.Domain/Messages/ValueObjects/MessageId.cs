using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Messages.ValueObjects;

public sealed class MessageId : ValueObject
{
    private MessageId(Guid value) => Value = value;

    public Guid Value { get; }

    public static MessageId Create()
    {
        return new MessageId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
