using MediatR;

namespace CarSalesManager.Application;

public class AllCarSalesQuery : IRequest<IEnumerable<CarSaleOutputModel>>
{
}
