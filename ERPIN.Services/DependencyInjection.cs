using ERPIN.Services.Config;
using ERPIN.Services.Services.Auth;
using ERPIN.Services.Services.INV;
using ERPIN.Services.Services.Purchases;
using ERPIN.Services.Services.Sales;
using ERPIN.Services.Services.Shared;
using Mapster;
using MapsterMapper;
using Microsoft.AspNet.Identity.EntityFramework;
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

        // Map Services 
        services.AddScoped<IUserLogService , UserLogService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ISLInvoiceService, SLInvoiceService>();
        services.AddScoped<ISLReturnService, SLReturnService>();
        services.AddScoped<IPRInvoiceService, PRInvoiceService>();
        services.AddScoped<IPRReturnService, PRReturnService>();
        services.AddScoped<ICustomersService, CustomersService>();
        services.AddScoped<IVendorsServices, VendorsServices>();
        services.AddScoped<IItemsService, ItemsService>();
        services.AddScoped<IStoresService, StoresService>();

        return services;
    }
}
