using BovIQ.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace BovIQ_E2.API.Extensions;

internal static class MigrationExtensions
{
    internal static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
}
