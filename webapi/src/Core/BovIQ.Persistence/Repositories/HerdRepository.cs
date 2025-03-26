using BovIQ.Domain.Entities;
using BovIQ.Domain.Repositories;
using BovIQ.Persistence.Abstractions;

namespace BovIQ.Persistence.Repositories;

public class HerdRepository(IApplicationDbContext context)
    : BaseRepository<Herd, int>(context), IHerdRepository
{
}
