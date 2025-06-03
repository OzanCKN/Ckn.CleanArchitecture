namespace Ckn.Application.Abstractions.Messaging;

using MediatR;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{ }