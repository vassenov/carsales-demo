using CarSalesManager.Infrastructure.Initializers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CarSalesManager.Host;

public static class ApplicationInitialization
{
    internal static IApplicationBuilder Initialize(this IApplicationBuilder builder)
    {
        using (var serviceScope = builder.ApplicationServices.CreateScope())
        {
            var initializers = serviceScope.ServiceProvider.GetServices<IInitializer>()!;
            foreach (var initializer in initializers)
            {
                initializer.Initialize();
            }

            return builder;
        }
    }
}
