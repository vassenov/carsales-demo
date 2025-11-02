using CarSalesManager.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CarSalesManager.Domain;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureDomain(this IServiceCollection services)
    {
        services.ConfigureFactories();

        return services;
    }

    private static IServiceCollection ConfigureFactories(this IServiceCollection services)
        => services
            .Scan(selector => selector
                    .FromAssemblies(Assembly.GetExecutingAssembly())
                    .AddClasses(classes => classes.AssignableTo(typeof(IFactory<>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime());
}
