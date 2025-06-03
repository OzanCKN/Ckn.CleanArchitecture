namespace Ckn.Application.Users.EventHandlers;

using Ckn.Domain.Common;
using Ckn.Domain.Events;

public class UserCreatedEventHandler : IDomainEventHandler<UserCreatedEvent>
{
    public Task Handle(UserCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        // Örnek: E-posta gönderimi, loglama, bildirim, vs.
        // await _emailService.SendWelcomeEmail(domainEvent.User.Email.Value);
        return Task.CompletedTask;
    }
}
