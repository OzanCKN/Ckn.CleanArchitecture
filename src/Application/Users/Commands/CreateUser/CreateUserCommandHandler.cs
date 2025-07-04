﻿namespace Ckn.Application.Users.Commands.CreateUser;

using Ckn.Application.Abstractions.Messaging;
using Ckn.Application.Common.Results;
using Ckn.Domain.Common;
using Ckn.Domain.Entities;
using Ckn.Domain.ValueObjects;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Guid>
{
    private readonly DomainEventDispatcher _domainEventDispatcher;

    public CreateUserCommandHandler(DomainEventDispatcher domainEventDispatcher)
    {
        _domainEventDispatcher = domainEventDispatcher;
    }

    public async Task<Result<Guid>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
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

        return Result<Guid>.Success(user.Id);
    }
}
