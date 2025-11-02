using CarSalesManager.Domain;
using CarSalesManager.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace CarSalesManager.Infrastructure.Initializers;

public class DbInitializer(ILogger<DbInitializer> logger, CarSalesDbContext context) : IInitializer
{
    public void Initialize()
    {
        AddInitialData();
    }

    private void AddInitialData()
    {
        var dealers = DealerData.GetData();
        foreach (var dealer in dealers)
        {
            context.Add(dealer);
        }

        context.SaveChanges();

        logger.LogInformation("Initialized Dealer data");
    }
}
