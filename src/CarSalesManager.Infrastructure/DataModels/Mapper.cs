using CarSalesManager.Application;

namespace CarSalesManager.Infrastructure.DataModels;

internal static partial class Mapper
{
    internal static CreateCarSaleCommand ToCommand(this CreateCarSaleModel dataModel)
        => new CreateCarSaleCommand
        {
            Manufacturer = dataModel.Manufacturer,
            Transmission = dataModel.Transmission,
            Dealer = dataModel.Dealer,
            Price = dataModel.Price
        };
}
