using BovIQ.Domain.Entities;

namespace BovIQ.Domain.Repositories;

public interface IHerdRepository : IBaseRepository<Herd, int>
{
    Task<bool> HerdExistsAsync(string herdName);
}
