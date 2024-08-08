using New_System.Domain.Core.BaseType;
using New_System.Domain.Posts.ValueObjects;

namespace New_System.Domain.Posts.Entity;

public sealed class Like : Entity<LikeId>
{
    private Like(Guid userId, Guid postId)
    {
        UserId = userId;
        PostId = postId;
    }
    public Guid UserId { get; private set; }
    public Guid PostId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public static Like Create(Guid userId, Guid postId)
    {
        return new(userId, postId);
    }
}
