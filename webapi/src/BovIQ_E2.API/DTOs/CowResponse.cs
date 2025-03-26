using BovIQ.Domain.Entities;

namespace BovIQ_E2.API.DTOs;

public sealed record CowResponse(
    int Id, 
    string? Name, 
    string EarTag, 
    DateTime FirstCalvingDate, 
    DateTime DateOfBirth,
    BreedResponse Breed,
    IReadOnlyList<MilkSession> DailyProduction);