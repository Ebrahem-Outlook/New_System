using New_System.Domain.Core.Events;

namespace New_System.Domain.Posts.Events;

public sealed record PostCreatedDomainEvent(Post Post) : DomainEvent();
