using ERPIN.Inventory.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERPIN.Inventory;
public static class DependencyInjection
{
    public static IServiceCollection AddInventoryModule(this IServiceCollection services,IConfiguration configuration)
    {
       var connectionString = configuration.GetConnectionString("DefaultConnection");

       if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
          
       services.AddDbContext<InventoryDbContext>(options => options.UseSqlServer(connectionString));

       return services;
    }

}
