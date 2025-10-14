using ERPIN.Domain.Entities.FI;
using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.Entities.PR;
using ERPIN.Domain.Entities.SH;
using ERPIN.Domain.Entities.SL;
using ERPIN.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERPIN.Infrastructure.Context;
public class AppDbContext : IdentityDbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<CostCenter> CostCenters { get; set; }
    public DbSet<Drawer> Drawers { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<PrInvoice> PrInvoices { get; set; }
    public DbSet<PrInvoiceDetail> PrInvoiceDetails { get; set; }
    public DbSet<PrReturn> PrReturns { get; set; }
    public DbSet<PrReturnDetail> PrReturnsDetails { get; set; }
    public DbSet<SlInvoice> SlInvoices { get; set; }
    public DbSet<SlInvoiceDetail> SlInvoiceDetails { get; set; }
    public DbSet<SlReturn> SlReturns { get; set; }
    public DbSet<SlReturnDetail> SlReturnsDetails { get; set; }
    public DbSet<Settings> Settings { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<IdentityUser>().ToTable("Users", "AUTH");
        modelBuilder.Entity<IdentityRole>().ToTable("Roles", "AUTH");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "AUTH");
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "AUTH");
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "AUTH");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "AUTH");
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "AUTH");
    }
}
