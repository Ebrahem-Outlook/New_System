using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Posts.ValueObjects;

public sealed class LikeId : ValueObject
{
    private LikeId(Guid value) => Value = value;

    public Guid Value { get; }

    public static LikeId New()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
