using BovIQ.Domain.Entities;
using BovIQ.Domain.Repositories;
using BovIQ.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BovIQ.Persistence.Repositories;

public class HerdRepository(IApplicationDbContext context)
    : BaseRepository<Herd, int>(context), IHerdRepository
{
    public Task<bool> HerdExistsAsync(string herdName) 
        => Context.Herds.AnyAsync(x => x.Name == herdName);

    public Task<bool> HerdExistsAsync(string herdName, int id) 
        => Context.Herds.Where(x => x.Id != id).AnyAsync(x => x.Name == herdName);
}
