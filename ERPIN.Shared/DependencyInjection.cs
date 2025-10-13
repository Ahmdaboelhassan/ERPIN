using ERPIN.Shared.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERPIN.Shared;
public static class DependencyInjection
{
    public static IServiceCollection AddSharedModule(this IServiceCollection services, IConfiguration configuration)
    {
       var connectionString = configuration.GetConnectionString("DefaultConnection");

       if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
          
       services.AddDbContext<SharedDbContext>(options => options.UseSqlServer(connectionString));

       return services;
    }

}
