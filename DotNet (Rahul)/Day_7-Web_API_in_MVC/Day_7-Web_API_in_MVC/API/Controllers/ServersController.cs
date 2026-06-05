using Day_7_Web_API_in_MVC.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Day_7_Web_API_in_MVC.Application.Dto;

namespace Day_7_Web_API_in_MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController(IServerRepo _repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAllServer()
        {
            return Ok(await _repo.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetServerById(int id)
        {
            if(id < 0)
                return  NotFound("Id must be positive");

            var server = await _repo.GetById(id);
            if(server == null)
                return NotFound("Given server id not exists.");

            return Ok(server);
        }

        [HttpPost]
        public async Task<ActionResult> AddServer(ServerDto server)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (server == null)
                return NotFound("Must enter server details.");

            var addServer = await _repo.AddServer(server);
            if(addServer == null)
                return Conflict("A server with this IP address already exists.");

            return Ok(new { message = "Server Added Successfully with this data.", data = addServer });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateServer(int id, ServerDto server)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id <= 0)
                return BadRequest("Id must be Positive.");
            if (server == null)
                return NotFound("Must enter server Details");
            var updateServer = await _repo.UpdateServer(id,server);
            if (updateServer == null)
            {
                var idExists = await _repo.GetById(id);
                if(idExists == null)
                    return NotFound(new { message = $"Server with ID {id} was not found." });

                return Conflict(new { message = $"The IP address '{server.IpAddress}' is already assigned to another server." });
            }
            return Ok(new { message = "Server Updated Successfully with this data.", data = updateServer });
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteServer(int id)
        {
            if (id <= 0)
                return BadRequest("Id must be Positive.");
            var deleteServer = await _repo.DeleteServer(id);
            if (deleteServer == null)
                return NotFound($"Server with id {id} not found.");

            return Ok(new { message = "Server deleted Successfully with this data.", data = deleteServer });
        }
    }
}
