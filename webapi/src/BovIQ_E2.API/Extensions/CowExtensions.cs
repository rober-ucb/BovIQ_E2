using BovIQ.Domain.Entities;
using BovIQ_E2.API.DTOs;

namespace BovIQ_E2.API.Extensions;

internal static class CowExtensions
{
    internal static Cow MapToEntity(this CreateCowRequest source) 
        => new()
        {
            BreedId = source.BreedId,
            Name = source.Name,
            EarTag = source.EarTag,
        };
    internal static Cow MapToEntity(this UpdateCowRequest source, Cow target)
    {
        target.BreedId = source.BreedId;
        target.Name = source.Name;
        target.EarTag = source.EarTag;
        return target;
    }
    internal static CowResponse MapToResponse(this Cow source)
        => new(
            source.Id,
            source.Name,
            source.EarTag,
            source.Breed?.MapToResponse());

    internal static IEnumerable<CowResponse> MapToResponse(this IEnumerable<Cow> source)
        => source.Select(MapToResponse);
}
