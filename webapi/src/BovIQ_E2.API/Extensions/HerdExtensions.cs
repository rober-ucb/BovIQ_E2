using BovIQ.Domain.Entities;
using BovIQ_E2.API.DTOs;

namespace BovIQ_E2.API.Extensions;

public static class HerdExtensions
{
    public static Herd MapToEntity(this CreateHerdRequest source) 
        => new()
        {
            Name = source.Name,
            OwnerId = source.OwnerId,
        };
}
