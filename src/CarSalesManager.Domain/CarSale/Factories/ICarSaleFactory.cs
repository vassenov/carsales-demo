using CarSalesManager.Domain.Abstractions;

namespace CarSalesManager.Domain;

public interface ICarSaleFactory : IFactory<CarSale>
{
    ICarSaleFactory WithManufacturer(string manufacturer);

    ICarSaleFactory WithTransmission(string transmission);

    ICarSaleFactory WithPrice(decimal price);
}
