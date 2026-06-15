using Day_17_Middleware_in_DotNET_Core_with_WebAPI.Dtos;
using Day_17_Middleware_in_DotNET_Core_with_WebAPI.Models;
using Day_17_Middleware_in_DotNET_Core_with_WebAPI.Services;
using Day_17_Middleware_in_DotNET_Core_with_WebAPI.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_17_Middleware_in_DotNET_Core_with_WebAPI.Controllers
{
    [ApiController]
    public class AlertsController(IAlertService _service) : ControllerBase
    {
        [HttpGet(AlertRoute.Alert.GetAllAlert)]
        public IActionResult GetAllAlerts()
        {
            //throw new Exception("Test exception for middleware");

            var listOfAllAlerts = _service.GetallAlerts();
            return Ok(new AlertResponse<List<Alert>>(listOfAllAlerts, "Data Retrieved Successfully."));
        }

        [HttpGet(AlertRoute.Alert.GetAlertById)]
        public IActionResult GetAlertById(int id)
        {
            var get = _service.GetAlertById(id);
            if (get == null)
                return NotFound(new AlertResponse<Alert>("Your given Id is not found."));

            return Ok(new AlertResponse<Alert>(get, "Data Retrieved Successfully."));
        }

        [HttpPost(AlertRoute.Alert.CreateAlert)]
        public IActionResult CreateAlert(AlertDto alertDto)
        {
            var add = _service.CreateAlert(alertDto);
            var wraperMessage = new AlertResponse<Alert>(add, "Data Retrieved Successfully.");
            return CreatedAtAction(nameof(GetAlertById), new { Id = add.Id }, wraperMessage);
        }

        [HttpPut(AlertRoute.Alert.UpdateAlert)]
        public IActionResult UpdateAlert(int id, AlertDto alertDto)
        {
            var update = _service.UpdateAlert(id, alertDto);
            if (update == null)
                return NotFound(new AlertResponse<Alert>("Your given Id is not found."));
            return Ok(new AlertResponse<Alert>(update, "Data Updated Successfully."));
        }

        [HttpDelete(AlertRoute.Alert.DeleteAlert)]
        public IActionResult DeleteAlert(int id)
        {
            var delete = _service.DeleteAlert(id);
            if (!delete)
                return NotFound(new AlertResponse<Alert>("Your given Id is not found."));
            return NoContent();
        }
    }
}

