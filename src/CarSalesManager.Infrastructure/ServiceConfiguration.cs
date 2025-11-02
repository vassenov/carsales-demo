using CarSalesManager.Application.Contracts;
using CarSalesManager.Infrastructure.Initializers;
using CarSalesManager.Infrastructure.Messaging;
using CarSalesManager.Infrastructure.Persistence;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CarSalesManager.Infrastructure;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
        => services
            .ConfigureWebComponents()
            .ConfigureRepositories()
            .ConfigureDatabase()
            .ConfigureMessaging()
            .ConfigureInitializers();

    private static IServiceCollection ConfigureWebComponents(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddApplicationPart(Assembly.GetExecutingAssembly())
            .AddControllersAsServices();

        return services;
    }

    private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        => services
            .Scan(selector => selector
                    .FromAssemblies(Assembly.GetExecutingAssembly())
                    .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
                    .AsMatchingInterface()
                    .WithScopedLifetime());

    private static IServiceCollection ConfigureDatabase(this IServiceCollection services)
    {
        services.AddDbContext<CarSalesDbContext>(
            options => options
                .UseInMemoryDatabase("DefaultConnection"));

        return services;
    }

    private static IServiceCollection ConfigureMessaging(this IServiceCollection services)
    {
        services.AddMassTransit(busConfig =>
        {
            busConfig.SetKebabCaseEndpointNameFormatter();
            busConfig.AddConsumer<CarSaleConsumer>();
            busConfig.UsingInMemory((context, config) => config.ConfigureEndpoints(context));
        });

        services.AddHostedService<Publisher>();

        return services;
    }

    private static IServiceCollection ConfigureInitializers(this IServiceCollection services)
        => services
            .Scan(selector => selector
                    .FromAssemblies(Assembly.GetExecutingAssembly())
                    .AddClasses(classes => classes.AssignableTo<IInitializer>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
}
