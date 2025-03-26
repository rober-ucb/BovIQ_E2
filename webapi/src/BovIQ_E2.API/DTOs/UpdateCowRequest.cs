using System.ComponentModel.DataAnnotations;

namespace BovIQ_E2.API.DTOs;

public sealed record UpdateCowRequest(
    [Required]
    [Range(1, int.MaxValue)]
    int BreedId,

    [Required]
    [Range(1, int.MaxValue)]
    int HerdId,

    [MaxLength(50)]
    string? Name,

    [MaxLength(10)]
    string EarTag,

    [Required]
    [DataType(DataType.Date)]
    DateTime FirstCalvingDate,

    [Required]
    [DataType(DataType.Date)]
    DateTime DateOfBirth);