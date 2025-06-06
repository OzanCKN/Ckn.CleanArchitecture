﻿namespace Ckn.Application.Abstractions.Messaging;

using MediatR;

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{ }
