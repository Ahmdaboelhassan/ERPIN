using ERPIN.Accounting.Models;
using Microsoft.EntityFrameworkCore;


namespace ERPIN.Accounting.Context;
public class AccountingDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<CostCenter> CostCenters { get; set; }
    public DbSet<Drawer> Drawers { get; set; }
    public AccountingDbContext(DbContextOptions<AccountingDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("ACC"); 
    }
}
