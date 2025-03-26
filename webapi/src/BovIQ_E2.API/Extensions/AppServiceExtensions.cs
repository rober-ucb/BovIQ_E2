﻿using BovIQ_E2.API.Services.Breeds;
using BovIQ_E2.API.Services.Cows;
using BovIQ_E2.API.Services.Herds;

namespace BovIQ_E2.API.Extensions;

internal static class AppServiceExtensions
{
    internal static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IHerdService, HerdService>();
        services.AddScoped<IBreedService, BreedService>();
        services.AddScoped<ICowService, CowService>();
        return services;
    }
}
