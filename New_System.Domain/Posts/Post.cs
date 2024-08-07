using New_System.Domain.Core.BaseType;
using New_System.Domain.Posts.Events;
using New_System.Domain.Posts.ValueObjects;

namespace New_System.Domain.Posts;

public sealed class Post : AggregateRoot<PostId>
{
    private Post(string title, string contect, List<Like> likes, List<Comment> comments)
        : base(PostId.Create())
    {  
        Title = title;
        Contect = contect;
        Likes = likes;
        Comments = comments;
        CreatedAt = DateTime.UtcNow;
    }

    private Post() : base() { }

    public string Title { get; private set; } = default!;
    public string Contect { get; private set; } = default!;
    public List<Like> Likes { get; private set; } = [];
    public List<Comment> Comments { get; private set; } = [];
    public DateTime CreatedAt { get; }
    public DateTime? UpdateAt { get; private set; }

    public static Post Create(string title, string contect, List<Like> likes, List<Comment> comments)
    {
        Post post = new(title, contect, likes, comments);

        post.RaiseDomainEvent(new PostCreatedDomainEvent(post));

        return post;
    }


}
