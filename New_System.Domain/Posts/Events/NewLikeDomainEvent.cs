﻿using New_System.Domain.Core.Events;
using New_System.Domain.Posts.Entity;

namespace New_System.Domain.Posts.Events;

public sealed record NewLikeDomainEvent(Like Like) : DomainEvent();
