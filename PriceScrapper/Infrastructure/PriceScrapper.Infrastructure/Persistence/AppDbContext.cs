using Microsoft.EntityFrameworkCore;
using PriceScrapper.Domain.Entities;

namespace PriceScrapper.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions opts)
        : base(opts)
    {
    }

    public DbSet<Stock> Stocks => Set<Stock>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }
}
