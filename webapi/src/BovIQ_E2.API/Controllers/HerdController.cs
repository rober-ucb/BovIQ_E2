using Azure.Core;
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
    public async Task<Results<Ok<IReadOnlyList<HerdResponse>>, BadRequest>> GetHerds()
    {
        var result = await herdService.GetHerdsAsync();
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.BadRequest();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(List<HerdResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok<HerdResponse>, BadRequest>> GetHerdById([FromRoute] int id)
    {
        var result = await herdService.GetByIdAsync(id);
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.BadRequest();
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<Results<Created<int>, BadRequest>> CreateHerd([FromBody] CreateHerdRequest request)
    {
        var result = await herdService.CreateHerdAsync(request);
        return result.IsSuccess
            ? TypedResults.Created(nameof(Created), result.Value)
            : TypedResults.BadRequest();
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok, BadRequest>> UpdateHerd(
        [FromRoute] int id, [FromBody] UpdateHerdRequest request)
    {
        var result = await herdService.UpdateHerdAsync(id, request);
        return result.IsSuccess
            ? TypedResults.Ok()
            : TypedResults.BadRequest();
    }
}
