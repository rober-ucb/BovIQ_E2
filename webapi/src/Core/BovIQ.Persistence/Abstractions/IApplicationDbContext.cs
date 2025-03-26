using BovIQ.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BovIQ.Persistence.Abstractions;

public interface IApplicationDbContext
{
    DbSet<ApplicationUser> Users { get; set; }
    DbSet<Cow> Cows { get; set; }
    DbSet<Herd> Herds {  get; set; }
    DbSet<Breed> Breeds { get; set; }
    DbSet<MilkSession> MilkSessions { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
}
