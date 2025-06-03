using Ckn.Application.Abstractions.Messaging;

namespace Ckn.Application.Users.Queries.GetUserDetail;

public record GetUserDetailQuery(Guid Id) : IQuery<GetUserDetailResponse>;
