using BovIQ_E2.API.Services.Herds;

namespace BovIQ_E2.API.Extensions;

internal static class AppServiceExtensions
{
    internal static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IHerdService, HerdService>();
        return services;
    }
}
