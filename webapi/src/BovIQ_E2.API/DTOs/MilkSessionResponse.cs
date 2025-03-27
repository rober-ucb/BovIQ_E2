using BovIQ.Domain.Entities;

namespace BovIQ_E2.API.DTOs;

public sealed record MilkSessionResponse(
    int Id,
    CowResponse Cow,
    MilkingTime MilkingTime,
    double MilkLiters,
    string Notes
);