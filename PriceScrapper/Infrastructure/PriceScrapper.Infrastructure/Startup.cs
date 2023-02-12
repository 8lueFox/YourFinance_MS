using Microsoft.Extensions.DependencyInjection;
using PriceScrapper.Infrastructure.Common;
using PriceScrapper.Infrastructure.Persistence;

namespace PriceScrapper.Infrastructure;

public static class Startup
{
   public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services
            .AddPersistance()
            .AddServices();
    }
}