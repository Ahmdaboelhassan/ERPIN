using ERPIN.Accounting.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERPIN.Accounting;
public static class DependencyInjection
{
    public static IServiceCollection AddAccountingModule(this IServiceCollection services,IConfiguration configuration)
    {
       var connectionString = configuration.GetConnectionString("DefaultConnection");

       if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
          
       services.AddDbContext<AccountingDbContext>(options => options.UseSqlServer(connectionString));

       return services;
    }

}
