using BovIQ.Domain.Entities;
using BovIQ.Domain.Repositories;
using BovIQ.Persistence.Abstractions;
using BovIQ_E2.API.DTOs;
using BovIQ_E2.API.Extensions;
using BovIQ_E2.API.Results;
using Microsoft.AspNetCore.Identity;

namespace BovIQ_E2.API.Services.Herds;

public class HerdService(
    IHerdRepository herdRepository,
    UserManager<ApplicationUser> userManager,
    IUnitOfWork unitOfWork) : IHerdService
{
    public async Task<Result<int>> CreateHerdAsync(CreateHerdRequest request)
    {
        if (await herdRepository.HerdExistsAsync(request.Name))
        {
            return Result.Failure<int>(Error.Validation("Herd.Duplicated", $"Name {request.Name} is already taken"));
        }

        if (await userManager.FindByIdAsync(request.OwnerId) is null)
        {
            return Result.Failure<int>(Error.Validation("User.NotFound", "User not found"));
        }
        Herd herd = request.MapToEntity();
        await herdRepository.InsertAsync(herd);
        await unitOfWork.SaveChangesAsync();
        return herd.Id;
    }

    public async Task<Result<HerdResponse>> GetByIdAsync(int id)
    {
        Herd? herd = await herdRepository.FindByIdAsync(id);
        if (herd is null)
        {
            return Result.Failure<HerdResponse>(Error.NotFound("Herd.NotFound", $"Herd with id {id} not found"));
        }
        return herd.MapToResponse();
    }

    public async Task<Result<IReadOnlyList<HerdResponse>>> GetHerdsAsync()
    {
        var herds = await herdRepository.GetAllAsync();
        return herds.Select(herd => new HerdResponse(herd.Id, herd.Name, herd.Cows.Count))
                    .ToList()
                    .AsReadOnly();
    }

    public async Task<Result> UpdateHerdAsync(int id, UpdateHerdRequest request)
    {
        Herd? herd = await herdRepository.FindByIdAsync(id);
        if (herd is null)
        {
            return Result.Failure(Error.NotFound("Herd.NotFound", $"Herd with id {id} not found"));
        }
        if (await userManager.FindByIdAsync(request.OwnerId) is null)
        {
            return Result.Failure<int>(Error.Validation("User.NotFound", "User not found"));
        }
        if (await herdRepository.HerdExistsAsync(request.Name, id))
        {
            return Result.Failure<int>(Error.Validation("Herd.Duplicated", $"Name {request.Name} is already taken"));
        }
        herd.Name = request.Name;
        herd.OwnerId = request.OwnerId;
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
