namespace Ckn.Application;

using Ckn.Application.Users.Commands;
using Ckn.Application.Users.EventHandlers;
using Ckn.Domain.Common;
using Ckn.Domain.Events;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Event handler'ları otomatik veya manuel ekle
        services.AddScoped<IDomainEventHandler<UserCreatedEvent>, UserCreatedEventHandler>();
        services.AddScoped<CreateUserCommandHandler>();  

        // Diğer Application servisleri...
        services.AddScoped<DomainEventDispatcher>();

        return services;
    }
}
