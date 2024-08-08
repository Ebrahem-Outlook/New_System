using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Posts.ValueObjects;

public sealed class Like : ValueObject
{
    private Like(Guid id, Guid userId, Guid postId)
    {
        Id = id;
        UserId = userId;
        PostId = postId;
    }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid PostId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public static Like Create(Guid id, Guid userId, Guid postId)
    {
        return new(id, userId, postId);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
        yield return UserId;
        yield return PostId;
        yield return CreatedAt;
    }
}
