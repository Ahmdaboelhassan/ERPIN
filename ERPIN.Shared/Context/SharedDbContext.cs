using ERPIN.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPIN.Shared.Context;
public class SharedDbContext : DbContext
{
    public DbSet<Settings> Settings { get; set; }

    public SharedDbContext(DbContextOptions<SharedDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("SH"); 
    }
}
