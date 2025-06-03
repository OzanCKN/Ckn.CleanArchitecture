namespace Ckn.Infrastructure;

using Ckn.Application.Abstractions.Authentication;
using Ckn.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Örneğin: DbContext, dış servis adapteları event bus cache vs.
        // services.AddDbContext<AppDbContext>(...);
        // services.AddScoped<IEmailSender, SmtpEmailSender>();

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}
