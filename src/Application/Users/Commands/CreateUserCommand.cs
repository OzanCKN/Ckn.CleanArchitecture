namespace Ckn.Application.Users.Commands;

using Ckn.Application.Abstractions.Messaging;
using Ckn.Domain.Enums;

public record CreateUserCommand(
    string UserName,
    string Email,
    string PasswordHash,
    string FirstName,
    string LastName,
    UserType UserType,
    decimal? CommissionRate = null,
    string? PhoneNumber = null
) : ICommand<Guid>;
