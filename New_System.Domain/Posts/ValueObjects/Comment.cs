using New_System.Domain.Core.BaseType;

namespace New_System.Domain.Posts.ValueObjects;

public sealed class Comment : ValueObject
{
    public Comment(Guid id, Guid userId, string content)
    {
        Id = id;
        UserId = userId;
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
        yield return UserId;
        yield return Content;
        yield return CreatedAt;
    }
}
