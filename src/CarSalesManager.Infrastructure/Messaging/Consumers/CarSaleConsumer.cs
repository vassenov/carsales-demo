using CarSalesManager.Infrastructure.DataModels;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarSalesManager.Infrastructure.Messaging;

public class CarSaleConsumer : Consumer<CreateCarSaleModel>
{
    public CarSaleConsumer(ILogger<CarSaleConsumer> logger, IMediator mediator)
        : base(logger, mediator)
    {
    }

    protected async override Task ConsumeCore(ConsumeContext<CreateCarSaleModel> context)
    {
        var createCarSaleCommand = context.Message.ToCommand();

        var output = await Mediator.Send(createCarSaleCommand);

        if (output.Id > 0)
            LogMessage(context.Message);
    }

    private void LogMessage(CreateCarSaleModel message)
    {
        var createdLogMessage =
            "Created, " +
            $"Manufacturer: {message.Manufacturer}, " +
            $"Transmission: {message.Transmission}," +
            $"Dealer: {message.Dealer}," +
            $"Price: {message.Price}";

        Logger.LogInformation(createdLogMessage);
    }
}
