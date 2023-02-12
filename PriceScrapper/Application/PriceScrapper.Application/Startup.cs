using MediatR;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PriceScrapper.Application;

public static class Startup
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assemblies = Assembly.GetExecutingAssembly();

        return services
            .AddMediatR(assemblies)
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
