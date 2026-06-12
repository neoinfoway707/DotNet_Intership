using Day_15_Validation_and_Routing_with_WebAPI.Attributes;
using Day_15_Validation_and_Routing_with_WebAPI.Dtos;
using Day_15_Validation_and_Routing_with_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_15_Validation_and_Routing_with_WebAPI.Controllers
{
    [ApiController]
    public class JobsController(IJobServices _service) : ControllerBase
    {
        [HttpGet(JobRoute.Jobs.GetAllJobs)]
        public IActionResult GetAllJobs()
        {
            return Ok(_service.GetAllJobs());
        }

        [HttpGet(JobRoute.Jobs.GetJobById)]
        public IActionResult GetJobsById([FromRoute] int id)
        {
            var get = _service.GetJobById(id);
            if (get == null)
                return NotFound("Your given id of Job is not exists.");
            return Ok(get);
        }

        [HttpPost(JobRoute.Jobs.CreateJob)]
        [JobTypeValidationActionFilter]
        public IActionResult CreateJob(JobsDto jobsDto)
        {
            if (jobsDto == null)
                return BadRequest("Must fill all job details.");
            var add = _service.CreateJob(jobsDto);
            return CreatedAtAction(nameof(GetJobsById), new { id = add.Id }, add);
        }

        [HttpPut(JobRoute.Jobs.UpdateJob)]
        [JobTypeValidationActionFilter]
        public IActionResult UpdateJob(int id, JobsDto jobsDto)
        {
            if (jobsDto == null)
                return BadRequest("Must fill all job details.");
            var update = _service.UpdateJob(id, jobsDto);
            if (update == null)
                return NotFound("Given Job Data Not found.");

            return Ok(update);
        }

        [HttpDelete(JobRoute.Jobs.DeleteJob)]
        public IActionResult DeleteJob(int id)
        {
            var delete = _service.DeleteJob(id);
            if (!delete)
                return NotFound("Your given Id is not found.");
            return NoContent();
        }
    }
}