using BovIQ_E2.API.DTOs;
using BovIQ_E2.API.Results;

namespace BovIQ_E2.API.Services.Breeds;

public interface IBreedService
{
    Task<Result<int>> CreateAsync(CreateBreedRequest request);
    Task<Result> UpdateAsync(int id, UpdateBreedRequest request);
    Task<Result<int>> DeleteAsync(int id);
    Task<Result<BreedResponse>> GetByIdAsync(int id);
    Task<Result<IReadOnlyList<BreedResponse>>> GetAllAsync();

}
