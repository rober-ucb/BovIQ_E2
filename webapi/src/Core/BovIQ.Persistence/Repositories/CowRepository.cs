using BovIQ.Domain.Entities;
using BovIQ.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BovIQ.Persistence.Repositories;

public class CowRepository(ApplicationDbContext context) : BaseRepository<Cow, int>(context), ICowRepository
{
    public Task<bool> EarTagExistsAsync(string earTag) 
        => Context.Cows.AnyAsync(x => x.EarTag == earTag);
    public override Task<List<Cow>> GetAllAsync()
    {
        return Context.Cows
            .Include(x => x.Breed)
            .Include(x => x.MilkSessions)
            .AsNoTracking()
            .ToListAsync();
    }
    public override Task<Cow?> FindByIdAsync(int id)
    {
        return Context.Cows
            .Include(x => x.Breed)
            .Include(x => x.MilkSessions)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<bool> EarTagExistsAsync(string earTag, int id) 
        => Context.Cows.Where(x => x.Id != id).AnyAsync(x => x.EarTag == earTag);
}
