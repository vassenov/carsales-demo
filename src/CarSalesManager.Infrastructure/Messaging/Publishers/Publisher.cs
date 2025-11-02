using CarSalesManager.Infrastructure.DataModels;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace CarSalesManager.Infrastructure.Messaging;

public class Publisher(IBus bus) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var messages = GetMessageBatch();
            await bus.PublishBatch(messages, cancellationToken);

            await Task.Delay(5000);
        }
    }

    private IEnumerable<CreateCarSaleModel> GetMessageBatch()
        => new CreateCarSaleMessageFaker().Generate(50);
}
