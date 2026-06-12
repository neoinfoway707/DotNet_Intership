using Day_15_Validation_and_Routing_with_WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Day_15_Validation_and_Routing_with_WebAPI.Attributes
{
    public class JobTypeValidationActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var jobDto = context.ActionArguments["jobsDto"] as JobsDto;
            if (jobDto != null)
            {
                var jobType = jobDto.JobType;
                string[] allowedTypes = { "full-time", "part-time", "remote", "contract" };
                if (!allowedTypes.Contains(jobType.ToLower()))
                {
                    context.ModelState.AddModelError("Job", "JobType must be Full-Time, Part-Time, Remote or Contract");
                    var porbelmDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(porbelmDetails);
                }
            }
        }
    }
}
