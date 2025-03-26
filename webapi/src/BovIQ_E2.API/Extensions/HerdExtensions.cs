using BovIQ.Domain.Entities;
using BovIQ_E2.API.DTOs;

namespace BovIQ_E2.API.Extensions;

public static class HerdExtensions
{
    public static Herd MapToEntity(this CreateHerdRequest source) 
        => new()
        {
            Name = source.Name,
            OwnerId = source.OwnerId,
        };
    public static HerdResponse MapToResponse(this Herd source)
        => new(source.Id, source.Name, source.Cows.Count);
    public static IEnumerable<HerdResponse> MapToResponse(this IEnumerable<Herd> source) 
        => source.Select(MapToResponse);
}
