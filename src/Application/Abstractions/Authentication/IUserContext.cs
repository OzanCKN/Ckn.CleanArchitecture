namespace Ckn.Application.Abstractions.Authentication;

public interface IUserContext
{
    Guid? UserId { get; }
    string? UserName { get; }
    string? Email { get; }
    IReadOnlyList<string> Roles { get; }
    bool IsAuthenticated { get; }
}
