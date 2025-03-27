using System.ComponentModel.DataAnnotations;

namespace BovIQ_E2.API.DTOs;

public sealed record CreateCowRequest(
    [Required]
    [Range(1, int.MaxValue)]
    int BreedId,

    [MaxLength(50)]
    string? Name,

    [MaxLength(10)]
    string EarTag);