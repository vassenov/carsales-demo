namespace CarSalesManager.Infrastructure.DataModels;

public class CreateCarSaleModel
{
    public required string Manufacturer { get; init; } = default!;

    public required string Transmission { get; init; } = default!;

    public required decimal Price { get; init; } = default!;

    public required string Dealer { get; init; } = default!;
}
