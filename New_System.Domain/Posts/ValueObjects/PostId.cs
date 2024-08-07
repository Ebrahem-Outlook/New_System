using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Posts.ValueObjects;

public sealed class PostId : ValueObject
{
    private PostId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static PostId Create()
    {
        return new PostId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
