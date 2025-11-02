using CarSalesManager.Domain.Abstractions;

namespace CarSalesManager.Application.Contracts;

public interface IRepository<in TEntity>
    where TEntity : class, IAggregateRoot
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
}
