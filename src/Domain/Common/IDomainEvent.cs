﻿namespace Ckn.Domain.Common;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
