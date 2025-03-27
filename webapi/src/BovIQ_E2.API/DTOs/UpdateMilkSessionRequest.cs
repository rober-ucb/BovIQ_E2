using BovIQ.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BovIQ_E2.API.DTOs;

public sealed record UpdateMilkSessionRequest(
    [Required]
    [Range(1, int.MaxValue)]
    int CowId,

    [Required]
    MilkingTime MilkingTime,

    [Required]
    [Range(0.1, double.MaxValue)]
    double MilkLiters,

    [MaxLength(150)]
    string? Notes
);