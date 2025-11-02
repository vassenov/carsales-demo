namespace CarSalesManager.Application;

public class CarSaleOutputModel
{
    public required int Id { get; set; }

    public required string Manufacturer { get; init; } = default!;

    public required string Transmission { get; init; } = default!;

    public required decimal Price { get; set; }
}
