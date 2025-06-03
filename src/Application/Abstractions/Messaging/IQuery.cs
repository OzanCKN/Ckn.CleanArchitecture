// src/Application/Abstractions/Messaging/IQuery.cs
namespace Ckn.Application.Abstractions.Messaging;

using MediatR;

public interface IQuery<out TResponse> : IRequest<TResponse> { }
