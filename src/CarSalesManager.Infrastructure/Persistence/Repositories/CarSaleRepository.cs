using CarSalesManager.Application;
using CarSalesManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarSalesManager.Infrastructure.Persistence;

public class CarSaleRepository : Repository<CarSale>, ICarSaleRepository
{
    public CarSaleRepository(CarSalesDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<IEnumerable<CarSale>> FindAllAsync(CancellationToken cancellationToken = default)
    {
        var carSales = await All()
                            .ToListAsync(cancellationToken);

        return carSales;
    }
}