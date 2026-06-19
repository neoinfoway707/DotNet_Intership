using Day_28_Advanced_Repository_Techniques.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Day_28_Advanced_Repository_Techniques.Validation
{
    public class ExpiryDateValidationActionFilterAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var request = context.ActionArguments["requestDto"] as MedicleSupplyRequestDto;
            if (request != null && request.ExpiryDate <= DateTime.UtcNow)
            {
                context.ModelState.AddModelError("Expiry Date", "Expiry date must be in the future.");
                var problems = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problems);
                return;
            }
            await next();
        }
    }
}