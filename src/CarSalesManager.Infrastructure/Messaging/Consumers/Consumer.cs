using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarSalesManager.Infrastructure.Messaging;

public abstract class Consumer<TMessage> : IConsumer<TMessage>
    where TMessage : class
{
    protected Consumer(ILogger<Consumer<TMessage>> logger, IMediator mediator)
    {
        Logger = logger;
        Mediator = mediator;
    }

    protected ILogger<Consumer<TMessage>> Logger { get; init; }

    protected IMediator Mediator { get; init; }

    public async Task Consume(ConsumeContext<TMessage> context)
    {
        try
        {
            await ConsumeCore(context);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Consumer error: {ex.Message}");
        }
    }

    protected abstract Task ConsumeCore(ConsumeContext<TMessage> context);
}
