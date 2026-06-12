using Day_14_Dependency_Injection__in_NET_Core.Dtos;
using Day_14_Dependency_Injection__in_NET_Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_14_Dependency_Injection__in_NET_Core.Controllers
{
    [ApiController]
    public class LeadSubmissionsController(ILeadSubmissionService _service) : ControllerBase
    {
        [HttpGet(Route.LeadSubmission.GetAllLead)]
        public IActionResult GetAllLeadSubmission()
        {
            var getAllDetails = _service.GetLeadSubmissions();
            return Ok(getAllDetails);
        }

        [HttpGet(Route.LeadSubmission.GetLeadById)]
        public IActionResult GetLeadSubmission(int id)
        {
            if (id <= 0)
                return BadRequest("Enter valid Lead Id.");
            var getDetails = _service.GetLeadSubmissionById(id);
            if (getDetails == null)
                return NotFound("Give id does not exists.");
            return Ok(getDetails);
        }

        [HttpPost(Route.LeadSubmission.CreateLead)]
        public IActionResult AddLeadSubmission([FromBody] LeadSubmissionDto leadSubmissionDto)
        {
            if (leadSubmissionDto == null)
                return BadRequest("Must Complete all details of Lead Submission form.");
            var addLead = _service.AddLeadSubmission(leadSubmissionDto);
            return CreatedAtAction(nameof(GetLeadSubmission), new { id = addLead.LeadId }, addLead);
        }
        [HttpPut(Route.LeadSubmission.UpdateLead)]
        public IActionResult UpdateLeadSubmission([FromRoute] int id, LeadSubmissionDto leadSubmissionDto)
        {
            if (id <= 0)
                return BadRequest("Enter valid Lead Id.");
            if (leadSubmissionDto == null)
                return BadRequest("Must fill correct details of Lead.");
            var update = _service.UpdateLeadSubmission(id, leadSubmissionDto);
            if (update == null)
                return NotFound("Give Lead Data notfound");

            return Ok(update);
        }
        [HttpDelete(Route.LeadSubmission.DeleteLead)]
        public IActionResult DeleteLeadSubmission([FromRoute]int id)
        {
            if (id <= 0)
                return BadRequest("Enter valid Lead Id.");
            var delete = _service.DeleteLeadSubmission(id);
            if (!delete)
                return NotFound("Give Id of Lead not found");
            return NoContent();
        }
    }
}