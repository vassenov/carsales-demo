using CarSalesManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static CarSalesManager.Domain.DealerConstants;

namespace CarSalesManager.Infrastructure.Persistence;

internal class DealerConfiguration : IEntityTypeConfiguration<Dealer>
{
    public void Configure(EntityTypeBuilder<Dealer> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .HasMaxLength(MaxNameLength)
            .IsRequired();

        builder.OwnsOne(
            x => x.Address,
            address =>
            {
                address
                    .Property(x => x.City)
                    .IsRequired();
                address
                    .Property(x => x.Street)
                    .IsRequired();
                address
                    .Property(x => x.StreetNumber)
                    .IsRequired();
                address
                    .Property(x => x.PostCode)
                    .IsRequired();
            });

        builder
            .HasMany(x => x.CarSales)
            .WithOne()
            .HasForeignKey("DealerId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade)
            .Metadata
            .PrincipalToDependent!
            .SetField("_carSales");

        builder.ToTable("Dealers");
    }
}
