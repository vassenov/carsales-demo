using MediatR;

namespace CarSalesManager.Application;

public class AllDealersQuery : IRequest<IEnumerable<DealerOutputModel>>
{
}
