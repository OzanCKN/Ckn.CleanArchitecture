namespace Ckn.Domain.Events;

using Ckn.Domain.Common;
using Ckn.Domain.Entities;

public class UserCreatedEvent : DomainEvent
{
    public User User { get; }

    public UserCreatedEvent(User user)
    {
        User = user;
    }
}
