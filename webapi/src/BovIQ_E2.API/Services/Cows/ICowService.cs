using BovIQ_E2.API.DTOs;
using BovIQ_E2.API.Results;

namespace BovIQ_E2.API.Services.Cows;

public interface ICowService
{
    Task<Result<int>> CreateAsync(CreateCowRequest request);
    Task<Result> UpdateAsync(int id, UpdateCowRequest request);
    Task<Result> DeleteAsync(int id);
    Task<Result<CowResponse>> GetByIdAsync(int id);
    Task<Result<IReadOnlyList<CowResponse>>> GetAllAsync();
}
