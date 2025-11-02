using CarSalesManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CarSalesManager.Infrastructure.Persistence;

internal class CarSaleConfiguration : IEntityTypeConfiguration<CarSale>
{
    public void Configure(EntityTypeBuilder<CarSale> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Manufacturer)
            .HasConversion(
                x => x.ToString(),
                x => Enum.Parse<Manufacturer>(x));

        builder
            .Property(x => x.Transmission)
            .HasConversion(
                x => x.ToString(),
                x => Enum.Parse<Transmission>(x));

        builder
            .Property(x => x.Price)
            .IsRequired();

        builder.ToTable("CarSales");
    }
}
