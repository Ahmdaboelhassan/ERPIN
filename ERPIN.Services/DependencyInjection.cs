using ERPIN.Services.IOptionSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERPIN.Services;
public static class DependencyInjection
{
    public static IServiceCollection AddServicesLayer(this IServiceCollection services , IConfiguration config)
    {
        services.Configure<JWT>(config.GetSection("JWT"));

        return services;
    }
}
