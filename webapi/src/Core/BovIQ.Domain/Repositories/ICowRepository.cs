using BovIQ.Domain.Entities;

namespace BovIQ.Domain.Repositories;

public interface ICowRepository : IBaseRepository<Cow, int>
{
    Task<bool> EarTagExistsAsync(string earTag);
    Task<bool> EarTagExistsAsync(string earTag, int id);
}
