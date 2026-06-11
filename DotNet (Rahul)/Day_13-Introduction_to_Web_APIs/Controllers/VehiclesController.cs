using Day_13_Introduction_to_Web_APIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_13_Introduction_to_Web_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Vehicle>> GetAllVehicles()
        {
            return Ok(VehicleService.GetAllVehicles());
        }

        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetVehicle(int id)
        {
            if (id <= 0)
                return BadRequest("Id must be greater than 0");
            var getVehicle = VehicleService.GetVehicle(id);
            if (getVehicle == null)
                return NotFound("Id not found");
            return Ok(getVehicle);
        }

        [HttpPost]
        public ActionResult<Vehicle> AddVehicle(VehicleDto vehicle)
        {
            if (vehicle == null)
                return BadRequest("Vehicle can't be null");
            var add = VehicleService.AddVehicle(vehicle);
            if (add == null)
                return BadRequest("Field to add vehicle data.");
            return CreatedAtAction(nameof(GetVehicle), new { id = add.Id }, add);
        }

        [HttpPut("{id}")]
        public ActionResult<Vehicle> UpdateVehicle([FromRoute] int id, VehicleDto vehicle)
        {
            if (id <= 0)
                return BadRequest("id must be greater then 0.");
            if (vehicle == null)
                return BadRequest("Must add vehicle details");
            var update = VehicleService.UpdateVehicle(id, vehicle);
            if (update == null)
                return NotFound("Vehicle with given Id not found.");

            return Ok(update);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            if (id <= 0)
                return BadRequest("id must be greater then 0.");
            var delete = VehicleService.DeleteVehicle(id);
            if (!delete)
                return NotFound("Give id not exists");
            return NoContent();
        }
    }
}