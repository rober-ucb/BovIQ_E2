using BovIQ.Domain.Entities;
using System.Text.Json.Serialization;

namespace BovIQ_E2.API.DTOs;

public sealed record CowResponse(
    int Id,
    string? Name,
    string EarTag,
    DateTime FirstCalvingDate,
    DateTime DateOfBirth,
    BreedResponse? Breed)
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BreedResponse? Breed { get; init; } = Breed;
}
