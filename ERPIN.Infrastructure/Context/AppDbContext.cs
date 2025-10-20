using ERPIN.Domain.Entities.AUTH;
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
public class AppDbContext : IdentityDbContext<AppUser, AppRole , int>
{
    #region FI
    public DbSet<Account> Accounts { get; set; }
    public DbSet<CostCenter> CostCenters { get; set; }
    public DbSet<Drawer> Drawers { get; set; }
    #endregion
    #region INV
    public DbSet<Item> Items { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<ItemStore> ItemStores { get; set; }
    #endregion
    #region PR
    public DbSet<PRInvoice> PRInvoices { get; set; }
    public DbSet<PRInvoiceDetail> PRInvoiceDetails { get; set; }
    public DbSet<PRReturn> PRReturns { get; set; }
    public DbSet<PRReturnDetail> PrReturnsDetails { get; set; }
    #endregion
    #region SL
    public DbSet<SLInvoice> SLInvoices { get; set; }
    public DbSet<SLInvoiceDetail> SLInvoiceDetails { get; set; }
    public DbSet<SLReturn> SLReturns { get; set; }
    public DbSet<SLReturnDetail> SLReturnsDetails { get; set; }
    #endregion
    public DbSet<Settings> Settings { get; set; }
    public DbSet<UserLog> UserLogs { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<AppUser>().ToTable("Users", "AUTH");
        modelBuilder.Entity<AppRole>().ToTable("Roles", "AUTH");
        modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles", "AUTH");

        // Skip the others
        modelBuilder.Ignore<IdentityUserClaim<int>>();
        modelBuilder.Ignore<IdentityUserLogin<int>>();
        modelBuilder.Ignore<IdentityUserToken<int>>();
        modelBuilder.Ignore<IdentityRoleClaim<int>>();

        // Configure Soft Delete Global Query Filter
        modelBuilder.Entity<PRInvoice>().HasQueryFilter(m => !m.IsDeleted);
        modelBuilder.Entity<PRInvoiceDetail>().HasQueryFilter(m => !m.IsDeleted);
        modelBuilder.Entity<PRReturn>().HasQueryFilter(m => !m.IsDeleted);
        modelBuilder.Entity<PRReturnDetail>().HasQueryFilter(m => !m.IsDeleted);
        modelBuilder.Entity<SLInvoice>().HasQueryFilter(m => !m.IsDeleted);
        modelBuilder.Entity<SLInvoiceDetail>().HasQueryFilter(m => !m.IsDeleted);
        modelBuilder.Entity<SLReturn>().HasQueryFilter(m => !m.IsDeleted);
        modelBuilder.Entity<SLReturnDetail>().HasQueryFilter(m => !m.IsDeleted);
        modelBuilder.Entity<Store>().HasQueryFilter(m => !m.IsDeleted);
        modelBuilder.Entity<Item>().HasQueryFilter(m => !m.IsDeleted);
        modelBuilder.Entity<Account>().HasQueryFilter(m => !m.IsDeleted);
        modelBuilder.Entity<CostCenter>().HasQueryFilter(m => !m.IsDeleted);
        modelBuilder.Entity<Drawer>().HasQueryFilter(m => !m.IsDeleted);


    }
}



