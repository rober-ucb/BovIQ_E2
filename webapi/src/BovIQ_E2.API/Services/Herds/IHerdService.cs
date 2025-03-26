using BovIQ_E2.API.DTOs;
using BovIQ_E2.API.Results;

namespace BovIQ_E2.API.Services.Herds;

public interface IHerdService
{
    Task<Result<IReadOnlyList<HerdResponse>>> GetHerdsAsync();
    Task<Result<int>> CreateHerdAsync(CreateHerdRequest request);
}
