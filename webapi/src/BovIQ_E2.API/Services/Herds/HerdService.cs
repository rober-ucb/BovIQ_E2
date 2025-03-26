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
            return Result.Failure<int>(Error.Validation("Herd.Duplicated", ""));
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

    public async Task<Result<IReadOnlyList<HerdResponse>>> GetHerdsAsync()
    {
        var herds = await herdRepository.GetAllAsync();
        return herds.Select(herd => new HerdResponse(herd.Id, herd.Name, herd.Cows.Count))
                    .ToList()
                    .AsReadOnly();
    }
}
