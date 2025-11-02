namespace CarSalesManager.Application;

public class DealerOutputModel
{
    public required int Id { get; set; }

    public required string Name { get; set; } = default!;

    public required string City { get; set; } = default!;

    public required string Street { get; set; } = default!;

    public required int StreetNumber { get; set; }

    public required int PostCode { get; set; }

    public IEnumerable<CarSaleOutputModel> CarSales { get; set; } = Enumerable.Empty<CarSaleOutputModel>();
}
