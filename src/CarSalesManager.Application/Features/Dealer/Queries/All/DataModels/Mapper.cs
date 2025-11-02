using CarSalesManager.Domain;

namespace CarSalesManager.Application;

internal static partial class Mapper
{
    internal static DealerOutputModel ToOutputModel(Dealer dealer)
        => new DealerOutputModel
        {
            Id = dealer.Id,
            Name = dealer.Name,
            City = dealer.Address.City,
            Street = dealer.Address.Street,
            StreetNumber = dealer.Address.StreetNumber,
            PostCode = dealer.Address.PostCode,
            CarSales = dealer.CarSales.ToOutputModels()
        };

    internal static IEnumerable<DealerOutputModel> ToOutputModels(this IEnumerable<Dealer> dealers)
        => dealers
            .Select(ToOutputModel)
            .ToList();
}
