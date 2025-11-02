using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CarSalesManager.Application;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services.AddMediator();

        return services;
    }

    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}
