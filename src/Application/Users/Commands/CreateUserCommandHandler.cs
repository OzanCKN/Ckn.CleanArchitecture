namespace Ckn.Application.Users.Commands;

using Ckn.Domain.Common;
using Ckn.Domain.Entities;
using Ckn.Domain.ValueObjects;

public class CreateUserCommandHandler
{
    private readonly DomainEventDispatcher _domainEventDispatcher;

    public CreateUserCommandHandler(DomainEventDispatcher domainEventDispatcher)
    {
        _domainEventDispatcher = domainEventDispatcher;
    }

    public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var email = new Email(command.Email);
        var user = User.Create(
            command.UserName,
            email,
            command.PasswordHash,
            command.FirstName,
            command.LastName,
            command.UserType,
            command.CommissionRate,
            command.PhoneNumber
        );


        // await _userRepository.AddAsync(user);

        // Domain event'leri publish et
        await _domainEventDispatcher.DispatchAsync(user.DomainEvents, cancellationToken);
        user.ClearDomainEvents();

        return user.Id;
    }
}
