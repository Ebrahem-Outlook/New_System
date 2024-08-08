using New_System.Domain.Core.BaseType;
using New_System.Domain.Posts.Entity;
using New_System.Domain.Posts.Events;
using New_System.Domain.Posts.ValueObjects;

namespace New_System.Domain.Posts;

public sealed class Post : AggregateRoot<PostId>, IAuditable
{

    private Post(string title, string contect) : base(PostId.Create())
    {  
        Title = title;
        Contect = contect;
        CreatedDate = DateTime.UtcNow;
    }

    private Post() : base() { }

    public string Title { get; private set; } = default!;
    public string Contect { get; private set; } = default!;
    public List<Like> Likes { get; private set; } = [];
    public List<Comment> Comments { get; private set; } = [];
    public List<Share> Shares { get; private set; } = [];

    public DateTime CreatedDate { get; }
    public DateTime? ModifiedDate { get; private set; }

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
        ModifiedDate = DateTime.UtcNow;

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

    public void AddShare(Share share)
    {
        Shares.Add(share);

        RaiseDomainEvent(new NewShareDomainEvent(share));
    }
}
