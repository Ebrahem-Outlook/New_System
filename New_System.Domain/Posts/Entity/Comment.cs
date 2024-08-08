using New_System.Domain.Core.BaseType;
using New_System.Domain.Posts.ValueObjects;

namespace New_System.Domain.Posts.Entity;

public sealed class Comment : Entity<CommentId>
{
    private Comment(Guid userId, Guid postId, string content)
    {
        UserId = userId;
        PostId = postId;
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }

    private Comment() { }

    public Guid UserId { get; }
    public Guid PostId { get; }
    public string Content { get; } = default!;
    public DateTime CreatedAt { get; }

    public static Comment Create(Guid userId, Guid postId, string content)
    {
        return new Comment(userId, postId, content);
    }
}
