using Ckn.Application.Abstractions.Messaging;
using Ckn.Application.Common.Results;

namespace Ckn.Application.Users.Queries.GetUserDetail;

internal class GetUserDetailQueryHandler : IQueryHandler<GetUserDetailQuery, GetUserDetailResponse>
{
    public async Task<Result<GetUserDetailResponse>> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
    {
        // Example data
        var response = new GetUserDetailResponse
        {
            Id = Guid.NewGuid(),
            UserName = "testuser",
            Email = "test@example.com",
            FullName = "Test User"
        };

        return Result<GetUserDetailResponse>.Success(response);
    }
}
