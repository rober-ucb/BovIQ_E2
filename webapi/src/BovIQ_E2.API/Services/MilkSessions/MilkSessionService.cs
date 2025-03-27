using BovIQ.Domain.Entities;
using BovIQ.Domain.Repositories;
using BovIQ.Persistence.Abstractions;
using BovIQ_E2.API.DTOs;
using BovIQ_E2.API.Extensions;
using BovIQ_E2.API.Results;

namespace BovIQ_E2.API.Services.MilkSessions;

public class MilkSessionService(
    IMilkSessionRepository milkSessionRepository,
    ICowRepository cowRepository,
    IUnitOfWork unitOfWork) : IMilkSessionService
{
    public async Task<Result<int>> CreateAsync(int cowId, CreateMilkSessionRequest request)
    {
        Cow? cow = await cowRepository.FindByIdAsync(cowId);
        if (cow is null)
        {
            return Result.Failure<int>(Error.NotFound("Cow.NotFound", "Cow not found."));
        }
        MilkSession milkSession = request.ToEntity();
        milkSession.Cow = cow;
        await milkSessionRepository.InsertAsync(milkSession);
        await unitOfWork.SaveChangesAsync();
        return cow.Id;
    }

    public async Task<Result<int>> DeleteAsync(int id)
    {
        MilkSession? milkSession = await milkSessionRepository.FindByIdAsync(id);
        if (milkSession is null)
        {
            return Result.Failure<int>(Error.NotFound("MilkSession.NotFound", "Milk session not found."));
        }
        milkSessionRepository.Delete(milkSession);
        await unitOfWork.SaveChangesAsync();
        return milkSession.Id;
    }

    public async Task<Result<IReadOnlyList<MilkSessionResponse>>> GetAllAsync(int cowId)
    {
        return (await milkSessionRepository.GetAllByCowIdAsync(cowId))
            .MapToResponse()
            .ToList()
            .AsReadOnly();
    }

    public async Task<Result<MilkSessionResponse>> GetByIdAsync(int id)
    {
        MilkSession? milkSession = await milkSessionRepository.FindByIdAsync(id);
        if (milkSession is null)
        {
            return Result.Failure<MilkSessionResponse>(Error.NotFound("MilkSession.NotFound", "Milk session not found."));
        }
        return milkSession.ToResponse();
    }

    public async Task<Result> UpdateAsync(int id, UpdateMilkSessionRequest request)
    {
        Cow? cow = await cowRepository.FindByIdAsync(request.CowId);
        if (cow is null)
        {
            return Result.Failure(Error.NotFound("Cow.NotFound", "Cow not found."));
        }
        MilkSession? milkSession = await milkSessionRepository.FindByIdAsync(id);
        if (milkSession is null)
        {
            return Result.Failure(Error.NotFound("MilkSession.NotFound", "Milk session doesn't exists"));
        }
        request.ToEntity(milkSession);
        milkSessionRepository.Update(milkSession);
        await unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
