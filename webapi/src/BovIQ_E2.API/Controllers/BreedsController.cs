using BovIQ_E2.API.DTOs;
using BovIQ_E2.API.Services.Breeds;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BovIQ_E2.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BreedsController(IBreedService breedService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<Results<Created<int>, BadRequest>> CreateBreedAsync([FromBody] CreateBreedRequest request)
    {
        var result = await breedService.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created(nameof(Created), result.Value)
            : TypedResults.BadRequest();
    }
    [HttpGet]
    [ProducesResponseType(typeof(List<BreedResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFound), StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok<IReadOnlyList<BreedResponse>>, NotFound>> GetAllBreedsAsync()
    {
        var result = await breedService.GetAllAsync();
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(BreedResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFound), StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok<BreedResponse>, NotFound>> GetBreedByIdAsync([FromRoute] int id)
    {
        var result = await breedService.GetByIdAsync(id);
        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.NotFound();
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok, BadRequest>> UpdateBreedAsync(
    [FromRoute] int id, [FromBody] UpdateBreedRequest request)
    {
        var result = await breedService.UpdateAsync(id, request);
        return result.IsSuccess
            ? TypedResults.Ok()
            : TypedResults.BadRequest();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFound), StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok, NotFound>> DeleteBreedAsync(
    [FromRoute] int id)
    {
        var result = await breedService.DeleteAsync(id);
        return result.IsSuccess
            ? TypedResults.Ok()
            : TypedResults.NotFound();
    }
}
