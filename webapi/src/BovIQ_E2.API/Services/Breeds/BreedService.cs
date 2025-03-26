using Azure.Core;
using BovIQ.Domain.Entities;
using BovIQ.Domain.Repositories;
using BovIQ.Persistence.Abstractions;
using BovIQ_E2.API.DTOs;
using BovIQ_E2.API.Extensions;
using BovIQ_E2.API.Results;

namespace BovIQ_E2.API.Services.Breeds;

public class BreedService(
    IBreedRepository breedRepository,
    IUnitOfWork unitOfWork) : IBreedService
{
    public async Task<Result<int>> CreateAsync(CreateBreedRequest request)
    {
        if (await breedRepository.BredNameExistsAsync(request.Name))
        {
            return Result.Failure<int>(Error.Validation("Breed.DuplicatedName","Breed name already exists"));
        }
        Breed breed = request.MapToEntity();
        await breedRepository.InsertAsync(breed);
        await unitOfWork.SaveChangesAsync();
        return breed.Id;
    }

    public async Task<Result<int>> DeleteAsync(int id)
    {
        Breed? breed = await breedRepository.FindByIdAsync(id);
        if (breed is null)
        {
            return Result.Failure<int>(Error.Validation("Breed.NotFound", "Breed not found"));
        }
        breedRepository.Delete(breed);
        await unitOfWork.SaveChangesAsync();
        return breed.Id;
    }

    public async Task<Result<IReadOnlyList<BreedResponse>>> GetAllAsync()
    {
        return (await breedRepository.GetAllAsync())
            .MapToResponse()
            .ToList()
            .AsReadOnly();
    }

    public async Task<Result<BreedResponse>> GetByIdAsync(int id)
    {
        Breed? breed = await breedRepository.FindByIdAsync(id);
        if (breed is null)
        {
            return Result.Failure<BreedResponse>(Error.Validation("Breed.NotFound", "Breed not found"));
        }
        return breed.MapToResponse();
    }

    public async Task<Result> UpdateAsync(int id, UpdateBreedRequest request)
    {
        Breed? breed = await breedRepository.FindByIdAsync(id);
        if (breed is null)
        {
            return Result.Failure(Error.Validation("Breed.NotFound", "Breed not found"));
        }

        if (await breedRepository.BredNameExistsAsync(request.Name, id))
        {
            return Result.Failure(Error.Validation("Breed.DuplicatedName", "Breed name already exists"));
        }
        breed.Name = request.Name;
        breed.Description = request.Description ?? string.Empty;
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
