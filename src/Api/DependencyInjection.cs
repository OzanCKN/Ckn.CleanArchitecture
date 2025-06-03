namespace Ckn.Api;

using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        // Web API'ye özel servisler, örn: JWT, UserContext, CORS, Swagger, vs.

        return services;
    }
}
