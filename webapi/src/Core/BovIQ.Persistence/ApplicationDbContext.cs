using BovIQ.Domain.Entities;
using BovIQ.Persistence.Abstractions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BovIQ.Persistence;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : IdentityDbContext<ApplicationUser>(options), IApplicationDbContext, IUnitOfWork
{
    public DbSet<Cow> Cows { get; set; }
    public DbSet<Herd> Herds { get; set; }
    public DbSet<Breed> Breeds { get; set; }
    public DbSet<MilkSession> MilkSessions { get ; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
