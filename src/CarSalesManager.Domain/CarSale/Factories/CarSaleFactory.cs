namespace CarSalesManager.Domain;

public class CarSaleFactory : ICarSaleFactory
{
    private Manufacturer _manufacturer = default!;
    private Transmission _transmission = default!;
    private decimal _price = default!;

    public ICarSaleFactory WithManufacturer(string manufacturer)
    {
        _manufacturer = Enum.Parse<Manufacturer>(manufacturer);

        return this;
    }

    public ICarSaleFactory WithTransmission(string transmission)
    {
        _transmission = Enum.Parse<Transmission>(transmission);

        return this;
    }

    public ICarSaleFactory WithPrice(decimal price)
    {
        _price = price;

        return this;
    }

    public CarSale Build()
    {
        if (_manufacturer is Manufacturer.Undefined || _transmission is Transmission.Undefined || _price == default)
        {
            throw new InvalidCarSaleException("Manufacturer, transmission and price must have a value.");
        }

        return new CarSale(_manufacturer, _transmission, _price);
    }
}
