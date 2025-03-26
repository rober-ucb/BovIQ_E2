using BovIQ.Domain.Entities;
using BovIQ_E2.API.DTOs;

namespace BovIQ_E2.API.Extensions;

internal static class CowExtensions
{
    internal static Cow MapToEntity(this CreateCowRequest source) 
        => new()
        {
            BreedId = source.BreedId,
            HerdId = source.HerdId,
            Name = source.Name,
            EarTag = source.EarTag,
            FirstCalvingDate = source.FirstCalvingDate,
            DateOfBirth = source.DateOfBirth
        };
    internal static Cow MapToEntity(this UpdateCowRequest source, Cow target)
    {
        target.BreedId = source.BreedId;
        target.HerdId = source.HerdId;
        target.Name = source.Name;
        target.EarTag = source.EarTag;
        target.FirstCalvingDate = source.FirstCalvingDate;
        target.DateOfBirth = source.DateOfBirth;
        return target;
    }
    internal static CowResponse MapToResponse(this Cow source)
        => new(
            source.Id,
            source.Name,
            source.EarTag,
            source.FirstCalvingDate,
            source.DateOfBirth,
            source.Breed.MapToResponse(),
            []);

    internal static IEnumerable<CowResponse> MapToResponse(this IEnumerable<Cow> source)
        => source.Select(MapToResponse);
}
