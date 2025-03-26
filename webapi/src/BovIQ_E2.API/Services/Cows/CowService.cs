using BovIQ.Domain.Entities;
using BovIQ.Domain.Repositories;
using BovIQ.Persistence.Abstractions;
using BovIQ_E2.API.DTOs;
using BovIQ_E2.API.Extensions;
using BovIQ_E2.API.Results;

namespace BovIQ_E2.API.Services.Cows;

public class CowService(
    ICowRepository cowRepository,
    IBreedRepository breedRepository,
    IUnitOfWork unitOfWork) : ICowService
{
    public async Task<Result<int>> CreateAsync(CreateCowRequest request)
    {
        Breed? breed = await breedRepository.FindByIdAsync(request.BreedId);
        if (breed is null)
        {
            return Result.Failure<int>(Error.NotFound("Breed.NotFound", "Breed not found"));
        }

        if (await cowRepository.EarTagExistsAsync(request.EarTag))
        {
            return Result.Failure<int>(Error.Validation("Cow.EarTagDuplicated", "Ear tag already exists"));
        }
        Cow cow = request.MapToEntity();
        cow.Breed = breed;
        await cowRepository.InsertAsync(cow);
        await unitOfWork.SaveChangesAsync();
        return cow.Id;
    }

    public async Task<Result> DeleteAsync(int id)
    {
        Cow? cow = await cowRepository.FindByIdAsync(id);
        if (cow is null)
        {
            return Result.Failure(Error.NotFound("Cow.NotFound", "Cow not found"));
        }
        cowRepository.Delete(cow);
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result<IReadOnlyList<CowResponse>>> GetAllAsync()
    {
        return (await cowRepository.GetAllAsync())
            .MapToResponse()
            .ToList()
            .AsReadOnly();
    }

    public async Task<Result<CowResponse>> GetByIdAsync(int id)
    {
        Cow? cow = await cowRepository.FindByIdAsync(id);
        if (cow is null)
        {
            return Result.Failure<CowResponse>(Error.NotFound("Cow.NotFound", "Cow not found"));
        }
        return cow.MapToResponse();
    }

    public async Task<Result> UpdateAsync(int id, UpdateCowRequest request)
    {
        Breed? breed = await breedRepository.FindByIdAsync(request.BreedId);
        if (breed is null)
        {
            return Result.Failure(Error.NotFound("Breed.NotFound", "Breed not found"));
        }
        Cow? cow = await cowRepository.FindByIdAsync(id);
        if (cow is null)
        {
            return Result.Failure(Error.NotFound("Cow.NotFound", "Cow not found"));
        }
        if (await cowRepository.EarTagExistsAsync(request.EarTag, id))
        {
            return Result.Failure(Error.Validation("Cow.EarTagDuplicated", "Ear tag already exists"));
        }
        cow.Breed = breed;
        request.MapToEntity(cow);
        cowRepository.Update(cow);
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
