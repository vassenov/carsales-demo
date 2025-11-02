using MediatR;

namespace CarSalesManager.Application;

public class CreateCarSaleCommand : IRequest<CreateCarSaleOutputModel>
{
    public string Manufacturer { get; set; } = default!;

    public string Transmission { get; set; } = default!;

    public decimal Price { get; set; } = default!;

    public string Dealer { get; set; } = default!;
}
