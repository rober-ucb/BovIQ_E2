using System.ComponentModel.DataAnnotations;

namespace BovIQ_E2.API.DTOs;

public sealed record UpdateBreedRequest(
    [Required]
    [MaxLength(50)]
    string Name,

    [MaxLength(150)]
    string? Description);