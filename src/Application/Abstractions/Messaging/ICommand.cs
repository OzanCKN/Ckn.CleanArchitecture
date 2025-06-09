using MediatR;
using Ckn.Application.Common.Results;

namespace Ckn.Application.Abstractions.Messaging;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
