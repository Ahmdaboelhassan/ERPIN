using ERPIN.Inventory.Models;
using ERPIN.Purchases.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPIN.Purchases.Context;
public class PurchasesDbContext : DbContext
{
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    public DbSet<Return> Returns { get; set; }
    public DbSet<ReturnDetail> ReturnsDetails { get; set; }
    public PurchasesDbContext(DbContextOptions<PurchasesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>().ToTable("Items", "IC");
        modelBuilder.Entity<Store>().ToTable("Stores", "IC");

        modelBuilder.HasDefaultSchema("IC"); 
    }
}
