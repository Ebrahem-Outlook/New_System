﻿using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Posts.ValueObjects;

public sealed class Comment : ValueObject
{
    private Comment(Guid userId, Guid postId, string content)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        PostId = postId;
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }

    private Comment() { }

    public Guid Id { get; }
    public Guid UserId { get; }
    public Guid PostId { get; }
    public string Content { get; } = default!;
    public DateTime CreatedAt { get; }

    public static Comment Create(Guid userId, Guid postId, string content)
    {
        return new Comment(userId, postId, content);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
        yield return UserId;
        yield return Content;
        yield return CreatedAt;
    }
}
