using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CarSalesManager.Infrastructure.Persistence;

public class CarSalesDbContext : DbContext
{
    public CarSalesDbContext(DbContextOptions<CarSalesDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
