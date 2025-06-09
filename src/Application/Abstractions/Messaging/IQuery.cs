using MediatR;
using Ckn.Application.Common.Results;

namespace Ckn.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
