using CarSalesManager.Domain.Abstractions;

using static CarSalesManager.Domain.Abstractions.Guard;

namespace CarSalesManager.Domain;

public class CarSale : Entity, IAggregateRoot
{
    private CarSale() { }

    protected internal CarSale(Manufacturer manufacturer, Transmission transmission, decimal price)
    {
        Manufacturer = manufacturer;
        Transmission = transmission;
        Price = price;
    }

    public Manufacturer Manufacturer { get; init; } = default!;

    public Transmission Transmission { get; init; } = default!;

    public decimal Price { get; private set; } = default!;

    public void UpdatePrice(decimal price)
    {
        ValidatePrice(price);

        Price = price;
    }

    private static void ValidatePrice(decimal price) 
        => AgainstNegativeValue<InvalidCarSaleException>(price);
}
