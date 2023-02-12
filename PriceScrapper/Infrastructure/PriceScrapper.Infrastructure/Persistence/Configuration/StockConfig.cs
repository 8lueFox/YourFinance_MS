using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceScrapper.Domain.Entities;

namespace PriceScrapper.Infrastructure.Persistence.Configuration;

public class StockConfig : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder
            .Property(b => b.Symbol)
                .HasMaxLength(10)
                .IsRequired();

        builder
            .Property(b => b.Name)
                .HasMaxLength(256)
                .IsRequired();
    }
}
