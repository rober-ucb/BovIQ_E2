using BovIQ.Domain.Repositories;
using BovIQ_E2.API.DTOs;
using BovIQ_E2.API.Results;

namespace BovIQ_E2.API.Services.Herds;

public class HerdService(IHerdRepository herdRepository) : IHerdService
{
    public async Task<Result<IReadOnlyList<HerdResponse>>> GetHerdsAsync()
    {
        var herds = await herdRepository.GetAllAsync();
        return herds.Select(herd => new HerdResponse(herd.Id, herd.Name, herd.Cows.Count))
                    .ToList()
                    .AsReadOnly();
    }
}
