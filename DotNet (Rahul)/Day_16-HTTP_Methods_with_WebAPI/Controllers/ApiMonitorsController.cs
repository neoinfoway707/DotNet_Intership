using Day_15_Validation_and_Routing_with_WebAPI.Controllers;
using Day_16_HTTP_Methods_with_WebAPI.Dtos;
using Day_16_HTTP_Methods_with_WebAPI.Models;
using Day_16_HTTP_Methods_with_WebAPI.Services;
using Day_16_HTTP_Methods_with_WebAPI.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace Day_16_HTTP_Methods_with_WebAPI.Controllers
{
    [ApiController]
    public class ApiMonitorsController(IApiMonitorServices _service) : ControllerBase
    {
        [HttpGet(ApiMonitorRoute.ApiMonitor.GetAllApiMonitors)]
        public IActionResult GetAllApiMonitors()
        {
            try
            {
                var listOfApiMonitors = _service.GetAllApiMonitors();
                return Ok(new ApiResponse<List<ApiMonitor>>(listOfApiMonitors, "Data retrieved Successfully."));
            }
            catch (Exception ex)
            {
                var wrapperRespone = new ApiResponse<List<ApiMonitor>>("Something went wrong on our end while fetching the monitors.", new List<string> { ex.Message });
                return StatusCode(StatusCodes.Status500InternalServerError, wrapperRespone);
            }
        }

        [HttpGet(ApiMonitorRoute.ApiMonitor.GetApiMonitorById)]
        public IActionResult GetApiMonitorById([FromRoute] int id)
        {
            try
            {
                var get = _service.GetApiMonitorById(id);
                if (get == null)
                    return NotFound(new ApiResponse<ApiMonitor>("Your given id of ApiMonitor is not exists."));
                return Ok(new ApiResponse<ApiMonitor>(get, "Data retrieved Successfully."));
            }
            catch (Exception ex)
            {
                var wrapperRespone = new ApiResponse<ApiMonitor>("Something went wrong on our end while fetching the monitors.", new List<string> { ex.Message });
                return StatusCode(StatusCodes.Status500InternalServerError, wrapperRespone);
            }
        }

        [HttpPost(ApiMonitorRoute.ApiMonitor.CreateApiMonitor)]
        public IActionResult CreateApiMonitor(ApiMonitorDto apiMonitorDto)
        {
            try
            {
                if (apiMonitorDto == null)
                    return BadRequest(new ApiResponse<ApiMonitor>("Must fill all ApiMonitor details."));

                var add = _service.CreateApiMonitor(apiMonitorDto);
                var wrappedResponse = new ApiResponse<ApiMonitor>(add, "Record created successfully.");
                return CreatedAtAction(nameof(GetApiMonitorById), new { id = add.Id }, wrappedResponse);
            }
            catch (Exception ex)
            {
                var wrapperRespone = new ApiResponse<ApiMonitor>("Something went wrong on our end while fetching the monitors.", new List<string> { ex.Message });
                return StatusCode(StatusCodes.Status500InternalServerError, wrapperRespone);
            }
        }

        [HttpPut(ApiMonitorRoute.ApiMonitor.UpdateApiMonitor)]
        public IActionResult UpdateApiMonitor(int id, ApiMonitorDto apiMonitorDto)
        {
            try
            {
                if (apiMonitorDto == null)
                    return BadRequest(new ApiResponse<ApiMonitor>("Must fill all ApiMonitor details."));
                var update = _service.UpdateApiMonitor(id, apiMonitorDto);
                if (update == null)
                    return NotFound(new ApiResponse<ApiMonitor>("Given ApiMonitor Data Not found."));

                return Ok(new ApiResponse<ApiMonitor>(update, "Data Updated Successfully."));
            }
            catch (Exception ex)
            {
                var wrapperRespone = new ApiResponse<ApiMonitor>("Something went wrong on our end while fetching the monitors.", new List<string> { ex.Message });
                return StatusCode(StatusCodes.Status500InternalServerError, wrapperRespone);
            }
        }

        [HttpDelete(ApiMonitorRoute.ApiMonitor.DeleteApiMonitor)]
        public IActionResult DeleteApiMonitor(int id)
        {
            try
            {
                var delete = _service.DeleteApiMonitor(id);
                if (!delete)
                    return NotFound(new ApiResponse<ApiMonitor>("Your given Id is not found."));
                return Ok(new ApiResponse<bool>(true, "Record deleted successfully."));
            }
            catch (Exception ex)
            {
                var wrapperRespone = new ApiResponse<ApiMonitor>("Something went wrong on our end while fetching the monitors.", new List<string> { ex.Message });
                return StatusCode(StatusCodes.Status500InternalServerError, wrapperRespone);
            }
        }
    }
}