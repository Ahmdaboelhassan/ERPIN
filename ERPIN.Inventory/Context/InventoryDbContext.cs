using ERPIN.Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPIN.Inventory.Context;
public class InventoryDbContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Store> Stores { get; set; }
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("IC"); 
    }
}
