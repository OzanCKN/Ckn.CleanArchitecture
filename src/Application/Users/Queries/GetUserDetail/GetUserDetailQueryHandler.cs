using Ckn.Application.Abstractions.Messaging;

namespace Ckn.Application.Users.Queries.GetUserDetail;

internal class GetUserDetailQueryHandler : IQueryHandler<GetUserDetailQuery, GetUserDetailResponse>
{
    public async Task<GetUserDetailResponse> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
    {
        // Example data
        var response = new GetUserDetailResponse
        {
            Id = Guid.NewGuid(),
            UserName = "testuser",
            Email = "test@example.com",
            FullName = "Test User"
        };

        return response;
    }
}
