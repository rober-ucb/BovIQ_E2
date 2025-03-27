using BovIQ.Domain.Entities;
using BovIQ_E2.API.DTOs;

namespace BovIQ_E2.API.Extensions;

internal static class MilkSessionExtensions
{
    internal static MilkSession ToEntity(this CreateMilkSessionRequest source) 
        => new()
        {
            CowId = source.CowId,
            MilkingTime = source.MilkingTime,
            MilkVolume = source.MilkLiters,
            Notes = source.Notes ?? string.Empty
        };
    internal static MilkSession ToEntity(this UpdateMilkSessionRequest source, MilkSession target)
    {
        target.CowId = source.CowId;
        target.MilkingTime = source.MilkingTime;
        target.MilkVolume = source.MilkLiters;
        target.Notes = source.Notes ?? string.Empty;
        return target;
    }
    internal static MilkSessionResponse ToResponse(this MilkSession source)
        => new(source.Id, 
               source.Cow.MapToResponse(), 
               source.MilkingTime, 
               source.MilkVolume, 
               source.Notes ?? string.Empty);
    internal static IEnumerable<MilkSessionResponse> MapToResponse(this IEnumerable<MilkSession> source)
        => source.Select(ToResponse);   
}
