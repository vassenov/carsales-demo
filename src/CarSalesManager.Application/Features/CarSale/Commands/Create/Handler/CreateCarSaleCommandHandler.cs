using CarSalesManager.Domain;
using MediatR;

namespace CarSalesManager.Application;

public class CreateCarSaleCommandHandler(
    ICarSaleFactory carSaleFactory, 
    IDealerRepository dealerRepository) 
        : IRequestHandler<CreateCarSaleCommand, CreateCarSaleOutputModel>
{
    public async Task<CreateCarSaleOutputModel> Handle(CreateCarSaleCommand request, CancellationToken cancellationToken)
    {
        var dealer = await dealerRepository.FindDealerByNameAsync(request.Dealer, cancellationToken);

        if (dealer is null)
        {
            return new CreateCarSaleOutputModel { Id = 0 };
        }

        var carSale = carSaleFactory
                        .WithManufacturer(request.Manufacturer)
                        .WithTransmission(request.Transmission)
                        .WithPrice(request.Price)
                        .Build();

        dealer.AddCarSale(carSale);
        await dealerRepository.UpdateAsync(dealer);

        return new CreateCarSaleOutputModel { Id = carSale.Id };
    }
}
