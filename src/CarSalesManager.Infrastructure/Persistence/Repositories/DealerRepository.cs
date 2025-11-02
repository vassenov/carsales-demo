using CarSalesManager.Application;
using CarSalesManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarSalesManager.Infrastructure.Persistence;

public class DealerRepository : Repository<Dealer>, IDealerRepository
{
    public DealerRepository(CarSalesDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<Dealer?> FindDealerByNameAsync(string dealerName, CancellationToken cancellationToken = default)
    {
        var dealer = await All()
                           .FirstOrDefaultAsync(x => x.Name == dealerName, cancellationToken);

        return dealer;
    }

    public async Task<IEnumerable<Dealer>> FindAllAsync(CancellationToken cancellationToken = default)
    {
        var dealers = await All()
                            .Include(c => c.CarSales)
                            .ToListAsync(cancellationToken);

        return dealers;
    }
}
