using BovIQ.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BovIQ_E2.API.Filters;

public class ValidateCowExistsAttribute : TypeFilterAttribute
{
    public ValidateCowExistsAttribute() : base(typeof(ValidateCowExistsFilter))
    {
    }
    private class ValidateCowExistsFilter(ICowRepository cowRepository) : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.RouteData.Values.TryGetValue("cowId", out object? value))
            {
                context.Result = new BadRequestObjectResult("CowId is required");
                return;
            }
            if (!int.TryParse(value?.ToString(), out int cowId))
            {
                context.Result = new BadRequestObjectResult("CowId must be an integer");
                return;
            }
            var cow = await cowRepository.FindByIdAsync(cowId);
            if (cow is null)
            {
                context.Result = new NotFoundObjectResult($"Cow with id {cowId} not found");
                return;
            }
            await next();
        }
    }
}
