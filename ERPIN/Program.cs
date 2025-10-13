using ERPIN.Accounting;
using ERPIN.Auth;
using ERPIN.Inventory;
using ERPIN.Purchases;
using ERPIN.Sales;
using ERPIN.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Modules

builder.Services
    .AddAccountingModule(builder.Configuration)
    .AddAuthModule(builder.Configuration)
    .AddInventoryModule(builder.Configuration)
    .AddPurchasesModule(builder.Configuration)
    .AddSalesModule(builder.Configuration)
    .AddSharedModule(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
