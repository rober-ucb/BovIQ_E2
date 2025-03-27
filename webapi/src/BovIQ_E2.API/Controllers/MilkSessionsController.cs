using BovIQ_E2.API.DTOs;
using BovIQ_E2.API.Filters;
using BovIQ_E2.API.Services.MilkSessions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BovIQ_E2.API.Controllers;

[Route("api/Cows/{cowId:int}/[controller]")]
[ApiController]
public class MilkSessionsController(IMilkSessionService milkSessionService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    [ValidateCowExists]
    public async Task<Results<Created<int>, BadRequest>> CreateMilkSessionAsync(
        [FromRoute] int cowId, [FromBody] CreateMilkSessionRequest request)
    {
        var result = await milkSessionService.CreateAsync(cowId, request);
        return result.IsSuccess
            ? TypedResults.Created(nameof(Created), result.Value)
            : TypedResults.BadRequest();
    }
    [HttpGet]
    [ProducesResponseType(typeof(List<MilkSessionResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFound), StatusCodes.Status400BadRequest)]
    [ValidateCowExists]
    public async Task<Results<Ok<IReadOnlyList<MilkSessionResponse>>, NotFound>> GetAllMilkSessionsAsync(
        [FromRoute] int cowId)
    {
        var result = await milkSessionService.GetAllAsync(cowId);
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(MilkSessionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFound), StatusCodes.Status400BadRequest)]
    [ValidateCowExists]
    public async Task<Results<Ok<MilkSessionResponse>, NotFound>> GetMilkSessionByIdAsync(
        [FromRoute] int id)
    {
        var result = await milkSessionService.GetByIdAsync(id);
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound();
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok, BadRequest>> UpdateCowAsync(
        [FromRoute] int id, [FromBody] UpdateMilkSessionRequest request)
    {
        var result = await milkSessionService.UpdateAsync(id, request);
        return result.IsSuccess
            ? TypedResults.Ok()
            : TypedResults.BadRequest();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFound), StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok, NotFound>> DeleteCowAsync([FromRoute] int id)
    {
        var result = await milkSessionService.DeleteAsync(id);
        return result.IsSuccess
            ? TypedResults.Ok()
            : TypedResults.NotFound();
    }
}
