using New_System.Domain.Core.Events;

namespace New_System.Domain.Posts.Events;

public sealed record PostDeletedDomainEvent(Post Post) : DomainEvent();
