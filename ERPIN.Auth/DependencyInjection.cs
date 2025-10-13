using ERPIN.Auth.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERPIN.Auth;
public static class DependencyInjection
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services,IConfiguration configuration)
    {
       var connectionString = configuration.GetConnectionString("DefaultConnection");

       if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
          
       services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(connectionString));

       return services;
    }

}
