using MediatR;

namespace CarSalesManager.Application;

public class AllDealersQueryHandler(IDealerRepository dealerRepository) : IRequestHandler<AllDealersQuery, IEnumerable<DealerOutputModel>>
{
    public async Task<IEnumerable<DealerOutputModel>> Handle(AllDealersQuery query, CancellationToken cancellationToken)
    {
        var dealers = await dealerRepository.FindAllAsync(cancellationToken);
        var outputModels = dealers.ToOutputModels();

        return outputModels;
    }
}
