using CarSalesManager.Application;
using CarSalesManager.Domain;
using CarSalesManager.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CarSalesManager.Host;

internal static class HostConfiguration
{
    public static IServiceCollection Setup(this IServiceCollection services)
        => services
            .ConfigureInfrastructure()
            .ConfigureApplication()
            .ConfigureDomain();
}
