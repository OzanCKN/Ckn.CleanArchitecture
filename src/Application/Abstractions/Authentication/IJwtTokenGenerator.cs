namespace Ckn.Application.Abstractions.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string userName, string email, IEnumerable<string> roles);
}
