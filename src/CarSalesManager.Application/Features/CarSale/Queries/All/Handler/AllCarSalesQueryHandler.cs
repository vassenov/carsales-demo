using MediatR;

namespace CarSalesManager.Application;

public class AllCarSalesQueryHandler(ICarSaleRepository carSaleRepository) 
    : IRequestHandler<AllCarSalesQuery, IEnumerable<CarSaleOutputModel>>
{
    public async Task<IEnumerable<CarSaleOutputModel>> Handle(AllCarSalesQuery query, CancellationToken cancellationToken)
    {
        var carSales = await carSaleRepository.FindAllAsync(cancellationToken);
        var outputModels = carSales.ToOutputModels();

        return outputModels;
    }
}
