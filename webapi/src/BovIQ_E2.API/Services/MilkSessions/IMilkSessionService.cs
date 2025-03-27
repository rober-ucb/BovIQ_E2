using BovIQ_E2.API.DTOs;
using BovIQ_E2.API.Results;

namespace BovIQ_E2.API.Services.MilkSessions;

public interface IMilkSessionService
{
    Task<Result<int>> CreateAsync(int cowId, CreateMilkSessionRequest request);
    Task<Result> UpdateAsync(int id, UpdateMilkSessionRequest request);
    Task<Result<int>> DeleteAsync(int id);
    Task<Result<MilkSessionResponse>> GetByIdAsync(int id);
    Task<Result<IReadOnlyList<MilkSessionResponse>>> GetAllAsync(int cowId);
}
