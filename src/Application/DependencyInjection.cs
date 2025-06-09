namespace Ckn.Application;

using Application.Users.Commands.CreateUser;
using Ckn.Application.Users.EventHandlers;
using Ckn.Domain.Common;
using Ckn.Domain.Events;
using FluentValidation;
using global::Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Event handler'ları otomatik veya manuel ekle
        services.AddScoped<IDomainEventHandler<UserCreatedEvent>, UserCreatedEventHandler>();
        services.AddScoped<CreateUserCommandHandler>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
        // Diğer Application servisleri...
        services.AddScoped<DomainEventDispatcher>();

        return services;
    }
}
