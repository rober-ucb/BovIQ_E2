using BovIQ.Domain.Entities;
using BovIQ_E2.API.DTOs;

namespace BovIQ_E2.API.Extensions;

internal static class BreedExtensions
{
    internal static Breed MapToEntity(this CreateBreedRequest source)
        => new()
        {
            Name = source.Name,
            Description = source.Description ?? string.Empty
        };
    internal static BreedResponse MapToResponse(this Breed source)
        => new(source.Id, source.Name, source.Description ?? string.Empty);
    internal static IEnumerable<BreedResponse> MapToResponse(this IEnumerable<Breed> source)
        => source.Select(MapToResponse);
}
