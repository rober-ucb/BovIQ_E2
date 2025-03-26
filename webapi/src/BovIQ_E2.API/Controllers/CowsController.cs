using BovIQ_E2.API.DTOs;
using BovIQ_E2.API.Services.Breeds;
using BovIQ_E2.API.Services.Cows;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BovIQ_E2.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CowsController(ICowService cowService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<Results<Created<int>, BadRequest>> CreateCowAsync(
        [FromBody] CreateCowRequest request)
    {
        var result = await cowService.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created(nameof(Created), result.Value)
            : TypedResults.BadRequest();
    }
    [HttpGet]
    [ProducesResponseType(typeof(List<CowResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFound), StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok<IReadOnlyList<CowResponse>>, NotFound>> GetAllCowsAsync()
    {
        var result = await cowService.GetAllAsync();
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(CowResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFound), StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok<CowResponse>, NotFound>> GetCowByIdAsync([FromRoute] int id)
    {
        var result = await cowService.GetByIdAsync(id);
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound();
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok, BadRequest>> UpdateCowAsync(
    [FromRoute] int id, [FromBody] UpdateCowRequest request)
    {
        var result = await cowService.UpdateAsync(id, request);
        return result.IsSuccess
            ? TypedResults.Ok()
            : TypedResults.BadRequest();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFound), StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok, NotFound>> DeleteCowAsync(
    [FromRoute] int id)
    {
        var result = await cowService.DeleteAsync(id);
        return result.IsSuccess
            ? TypedResults.Ok()
            : TypedResults.NotFound();
    }
}
