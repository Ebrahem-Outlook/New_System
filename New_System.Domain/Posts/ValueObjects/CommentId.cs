using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Posts.ValueObjects;

public sealed class CommentId : ValueObject
{
    private CommentId(Guid value) => Value = value;

    public Guid Value { get; }

    public static CommentId Create()
    {
        return new CommentId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
