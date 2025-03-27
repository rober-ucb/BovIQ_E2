using BovIQ.Domain.Entities;

namespace BovIQ.Domain.Repositories;

public interface IMilkSessionRepository : IBaseRepository<MilkSession, int>
{
    Task<List<MilkSession>> GetAllByCowIdAsync(int cowId);
}
