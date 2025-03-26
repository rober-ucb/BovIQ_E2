using BovIQ_E2.API.DTOs;
using BovIQ_E2.API.Services.Herds;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BovIQ_E2.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HerdController(IHerdService herdService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(List<HerdResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok<IReadOnlyList<HerdResponse>>, BadRequest>> GetHerdsAsync()
    {
        var result = await herdService.GetHerdsAsync();
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.BadRequest();
    }
}
