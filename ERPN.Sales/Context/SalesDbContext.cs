using ERPN.Sales.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPN.Sales.Context;
public class SalesDbContext : DbContext
{
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    public DbSet<Return> Returns { get; set; }
    public DbSet<ReturnDetail> ReturnsDetails { get; set; }
    public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("SL"); 
    }
}
