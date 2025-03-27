using BovIQ.Domain.Entities;
using BovIQ.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BovIQ.Persistence.Repositories;

public class MilkSessionRepository(ApplicationDbContext context) 
    : BaseRepository<MilkSession, int>(context), IMilkSessionRepository
{
    public override Task<List<MilkSession>> GetAllAsync() 
        => Context.MilkSessions
            .Include(x => x.Cow)
            .AsNoTracking()
            .ToListAsync();
    public Task<List<MilkSession>> GetAllByCowIdAsync(int cowId)
        => Context.MilkSessions
            .Include(x => x.Cow)
            .AsNoTracking()
            .Where(x => x.CowId == cowId)
            .ToListAsync();
    public override Task<MilkSession?> FindByIdAsync(int id) 
        => Context.MilkSessions
            .IgnoreAutoIncludes()
            .Include(x => x.Cow)
            .FirstOrDefaultAsync(x => x.Id == id);
}
