namespace CarSalesManager.Domain.Abstractions;

public abstract class Entity
{
    public int Id { get; protected set; } = default!;
}
