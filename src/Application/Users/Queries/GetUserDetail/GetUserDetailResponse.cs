
namespace Ckn.Application.Users.Queries.GetUserDetail;

internal class GetUserDetailResponse
{
    public Guid Id { get; internal set; }
    public string UserName { get; internal set; }
    public string FullName { get; internal set; }
    public string Email { get; internal set; }
}