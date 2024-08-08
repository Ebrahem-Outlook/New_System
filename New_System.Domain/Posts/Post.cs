using New_System.Domain.Core.BaseType;
using New_System.Domain.Posts.Events;
using New_System.Domain.Posts.ValueObjects;

namespace New_System.Domain.Posts;

public sealed class Post : AggregateRoot<PostId>
{
    private Post(string title, string contect) : base(PostId.Create())
    {  
        Title = title;
        Contect = contect;
        CreatedAt = DateTime.UtcNow;
    }

    private Post() : base() { }

    public string Title { get; private set; } = default!;
    public string Contect { get; private set; } = default!;
    public List<Like> Likes { get; private set; } = [];
    public List<Comment> Comments { get; private set; } = [];
    public DateTime CreatedAt { get; }
    public DateTime? UpdateAt { get; private set; }

    public static Post Create(string title, string contect)
    {
        Post post = new(title, contect);

        post.RaiseDomainEvent(new PostCreatedDomainEvent(post));

        return post;
    }

    public void Update(string title, string contect)
    {
        Title = title;
        Contect = contect;

        RaiseDomainEvent(new PostUpdatedDomainEvent(this));
    }

    public void AddLike(Like like)
    {
        Likes.Add(like);

        RaiseDomainEvent(new NewLikeDomainEvent(like));
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);

        RaiseDomainEvent(new NewCommentDomainEvent(comment));
    }
}
