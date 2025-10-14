using ERPIN.Services.Config;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ERPIN.Services;
public static class DependencyInjection
{
    public static IServiceCollection AddServicesLayer(this IServiceCollection services , IConfiguration config)
    {
        services.Configure<JWT>(config.GetSection("JWT"));

        var mapConfig = TypeAdapterConfig.GlobalSettings;
        mapConfig.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(mapConfig);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
