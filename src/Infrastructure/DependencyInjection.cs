namespace Ckn.Infrastructure;

using Ckn.Application.Abstractions.Authentication;
using Ckn.Application.Common;
using Ckn.Infrastructure.Authentication;
using Ckn.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Örneğin: DbContext, dış servis adapteları event bus cache vs.
        // services.AddDbContext<AppDbContext>(...);
        // services.AddScoped<IEmailSender, SmtpEmailSender>();
        services.AddHttpContextAccessor();
        services.AddScoped<IUserContext, UserContext>();

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<AppDbContext>(options =>
         options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
