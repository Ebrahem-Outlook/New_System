﻿using New_System.Domain.Core.Events;
using New_System.Domain.Posts.ValueObjects;

namespace New_System.Domain.Posts.Events;

public sealed record NewLikeDomainEvent(Like Like) : DomainEvent();
