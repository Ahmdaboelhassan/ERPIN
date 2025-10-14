using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERPIN.Domain;
public static class DependencyInjection
{
    public static IServiceCollection AddDomainLayer(this IServiceCollection services , IConfiguration config)
    {
       

        return services;
    }
}
