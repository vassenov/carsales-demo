using CarSalesManager.Domain;

namespace CarSalesManager.Application;

internal static partial class Mapper
{
    internal static CarSaleOutputModel ToOutputModel(CarSale carSale)
        => new CarSaleOutputModel
        {
            Id = carSale.Id,
            Manufacturer = carSale.Manufacturer.ToString(),
            Transmission = carSale.Transmission.ToString(),
            Price = carSale.Price
        };

    internal static IEnumerable<CarSaleOutputModel> ToOutputModels(this IEnumerable<CarSale> carSales)
        => carSales
            .Select(ToOutputModel)
            .ToList();
}
