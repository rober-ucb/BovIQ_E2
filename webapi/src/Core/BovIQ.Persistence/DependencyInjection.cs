using BovIQ.Domain.Entities;
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
        services.AddScoped<IBreedRepository, BreedRepository>();
        services.AddScoped<ICowRepository, CowRepository>();
        services.AddScoped<IMilkSessionRepository, MilkSessionRepository>();
        return services;
    }
    public static IServiceCollection AddDatabaseProvider(
        this IServiceCollection services,
        IConfiguration configuration)
        => services.AddSqlServer<ApplicationDbContext>(configuration.GetConnectionString(_sectionName), optionsAction: options =>
        {
            options.UseSeeding((context, _) =>
            {
                ApplicationUser user = new ApplicationUser
                {
                    FirstName = "Robert Leon",
                    LastName = "Guerrero Mendoza",
                    Email = "robert@email.com",
                    UserName = "robert@email.com"
                };
                if (context.Set<ApplicationUser>().Any(x => x.Email == user.Email))
                {
                    return;
                }
                context.Set<ApplicationUser>().Add(user);
                context.SaveChanges();
            });
        });
}
