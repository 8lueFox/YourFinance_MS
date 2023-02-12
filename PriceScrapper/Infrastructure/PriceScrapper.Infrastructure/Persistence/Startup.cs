using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YF.SharedKernel.Common;
using YF.SharedKernel.Common.Persistence;

namespace PriceScrapper.Infrastructure.Persistence;

internal static class Startup
{
    internal static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        return services
            .AddDbContext<AppDbContext>(opt =>
                opt.UseInMemoryDatabase("YourFinanceDbMemory"))
            .AddRepositories();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Add Repositories
        services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

        foreach (var aggregateRootType in
            typeof(BaseEntity).Assembly.GetExportedTypes()
                .Where(t => typeof(BaseEntity).IsAssignableFrom(t) && t.IsClass)
                .ToList())
        {
            // Add ReadRepositories.
            services.AddScoped(typeof(IReadRepository<>).MakeGenericType(aggregateRootType), sp =>
                sp.GetRequiredService(typeof(IRepository<>).MakeGenericType(aggregateRootType)));
        }

        return services;
    }
}
