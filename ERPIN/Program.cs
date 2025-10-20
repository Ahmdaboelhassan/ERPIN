using Asp.Versioning;
using ERPIN.Domain;
using ERPIN.Infrastructure;
using ERPIN.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});

// Add Modules
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors();

builder.Services
    .AddDomainLayer(builder.Configuration)
    .AddInfrastructureLayer(builder.Configuration)
    .AddServicesLayer(builder.Configuration);
        

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(opt => opt.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.MapControllers();

app.MapGet("/ping", () => Results.Ok("App Is Running...."));

app.Run();
