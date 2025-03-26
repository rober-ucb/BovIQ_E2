using BovIQ.Domain.Repositories;
using BovIQ.Persistence.Abstractions;
using BovIQ.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BovIQ.Persistence;

public static class DependencyInjection
{
    private const string _sectionName = "Database";
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IHerdRepository, HerdRepository>();
        return services;
    }
    public static IServiceCollection AddDatabaseProvider(
        this IServiceCollection services,
        IConfiguration configuration) 
        => services.AddSqlServer<ApplicationDbContext>(configuration.GetConnectionString(_sectionName));
}
