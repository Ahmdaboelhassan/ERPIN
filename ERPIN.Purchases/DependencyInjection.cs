using ERPIN.Purchases.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERPIN.Purchases;
public static class DependencyInjection
{
    public static IServiceCollection AddPurchasesModule(this IServiceCollection services,IConfiguration configuration)
    {
       var connectionString = configuration.GetConnectionString("DefaultConnection");

       if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
          
       services.AddDbContext<PurchasesDbContext>(options => options.UseSqlServer(connectionString));

       return services;
    }

}
