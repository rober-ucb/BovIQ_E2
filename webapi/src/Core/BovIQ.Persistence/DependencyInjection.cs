using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BovIQ.Persistence;

public static class DependencyInjection
{
    private const string _sectionName = "DataBase";
    public static IServiceCollection AddDatabaseProvider(
        this IServiceCollection services,
        IConfiguration configuration) 
        => services.AddSqlServer<ApplicationDbContext>(configuration.GetConnectionString(_sectionName));
}
