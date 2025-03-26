using BovIQ_E2.API.DTOs;
using BovIQ_E2.API.Results;

namespace BovIQ_E2.API.Services.Herds;

public interface IHerdService
{
    Task<Result<IReadOnlyList<HerdResponse>>> GetAllAsync();
    Task<Result<int>> CreateAsync(CreateHerdRequest request);
    Task<Result> UpdateAsync(int id, UpdateHerdRequest request);
    Task<Result<HerdResponse>> GetByIdAsync(int id);
}
