using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Posts.ValueObjects;

public sealed class ShareId : ValueObject
{
    private ShareId(Guid value) => Value = value;

    public Guid Value { get; }

    public static ShareId Create()
    {
        return new ShareId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
