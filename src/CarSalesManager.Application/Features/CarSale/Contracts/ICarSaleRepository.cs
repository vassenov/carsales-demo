using CarSalesManager.Application.Contracts;
using CarSalesManager.Domain;

namespace CarSalesManager.Application;

public interface ICarSaleRepository : IRepository<CarSale>
{
    Task<IEnumerable<CarSale>> FindAllAsync(CancellationToken cancellationToken = default);
}
