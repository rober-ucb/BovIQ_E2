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
    public async Task<Result<int>> CreateAsync(CreateHerdRequest request)
    {
        if (await herdRepository.HerdExistsAsync(request.Name))
        {
            return Result.Failure<int>(Error.Validation("Herd.Duplicated", $"Name {request.Name} is already taken"));
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

    public async Task<Result<IReadOnlyList<HerdResponse>>> GetAllAsync()
    {
        return (await herdRepository.GetAllAsync())
            .MapToResponse()
            .ToList()
            .AsReadOnly();
    }

    public async Task<Result> UpdateAsync(int id, UpdateHerdRequest request)
    {
        Herd? herd = await herdRepository.FindByIdAsync(id);
        if (herd is null)
        {
            return Result.Failure(Error.NotFound("Herd.NotFound", $"Herd with id {id} not found"));
        }
        if (await herdRepository.HerdExistsAsync(request.Name, id))
        {
            return Result.Failure<int>(Error.Validation("Herd.Duplicated", $"Name {request.Name} is already taken"));
        }
        herd.Name = request.Name;
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
