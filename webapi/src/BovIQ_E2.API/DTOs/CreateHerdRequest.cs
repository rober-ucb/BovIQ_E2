using System.ComponentModel.DataAnnotations;

namespace BovIQ_E2.API.DTOs;

public sealed record CreateHerdRequest(
    [Required]
    [MaxLength(50)]
    string Name);