using CarSalesManager.Application.Contracts;
using CarSalesManager.Domain;

namespace CarSalesManager.Application;

public interface IDealerRepository : IRepository<Dealer>
{
    Task<Dealer?> FindDealerByNameAsync(string dealerName, CancellationToken cancellationToken = default);

    Task<IEnumerable<Dealer>> FindAllAsync(CancellationToken cancellationToken = default);
}
