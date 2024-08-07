using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Posts.ValueObjects;

public sealed class Like : ValueObject
{
    public Like(Guid id, Guid userId, DateTime createdAt)
    {
        Id = id;
        UserId = userId;
        CreatedAt = createdAt;
    }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
        yield return UserId;
        yield return CreatedAt;
    }
}
