using Day_20_Logging_with_WebAPI.Dtos;
using Day_20_Logging_with_WebAPI.Models;
using Day_20_Logging_with_WebAPI.Services;
using Day_20_Logging_with_WebAPI.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace Day_20_Logging_with_WebAPI.Controllers
{
    [ApiController]
    public class SmartContainerController(ISmartContainerServices _service, ILogger<SmartContainerController> _logger) : ControllerBase
    {
        [HttpGet(SmartContainerRoute.SmsrtContainer.GetAllSmsrtContainer)]
        public async Task<IActionResult> GetAllSmartContainer()
        {
            //throw new Exception("Checking Unhandling exception");
            var listOfAllSmartContainer = await _service.GetAllSmartContainers();
            _logger.LogInformation("Fetching all active containers");

            return Ok(new SmartContainerResponse<List<SmartContainer>>(listOfAllSmartContainer, "Data Retrieved Successfully."));
        }

        [HttpGet(SmartContainerRoute.SmsrtContainer.GetSmsrtContainerById)]
        public async Task<IActionResult> GetSmartContainerById(int id)
        {
            var getSmartContainer = await _service.GetSmartContainerById(id);
            if (getSmartContainer == null)
            {
                _logger.LogWarning("Container with Id {Id} not found", id);
                return NotFound(new SmartContainerResponse<SmartContainer>("Given Id of Smart Container Not Found."));
            }

            _logger.LogInformation("Fetching container with Id {Id}", id);
            return Ok(new SmartContainerResponse<SmartContainer>(getSmartContainer, "Data Retrieved Successfully."));
        }

        [HttpPost(SmartContainerRoute.SmsrtContainer.CreateSmsrtContainer)]
        public async Task<IActionResult> CreateSmartContainer(SmartContainerDto containerDto)
        {
            var addSmartContainer = await _service.CreateSmartContainer(containerDto);
            var wrapperClass = new SmartContainerResponse<SmartContainer>(addSmartContainer, "SmartContainer Created Successfully.");
            _logger.LogInformation("Container {TelemetryCode} created with Id {Id}",
                addSmartContainer.TelemetryCode, addSmartContainer.Id);

            return CreatedAtAction(nameof(GetSmartContainerById), new { Id = addSmartContainer.Id }, wrapperClass);
        }

        [HttpPut(SmartContainerRoute.SmsrtContainer.UpdateSmsrtContainer)]
        public async Task<IActionResult> UpdateSmartContainer(int id, SmartContainerDto containerDto)
        {
            var updateSmartContainer = await _service.UpdateSmartContainer(id, containerDto);

            if (updateSmartContainer == null)
            {
                _logger.LogWarning("Container {Id} not found for update", id);
                return NotFound(new SmartContainerResponse<SmartContainer>("Given Id of Smart Container Not Found."));
            }
            _logger.LogInformation("Container {TelemetryCode} Updated with Id {Id}",
               updateSmartContainer.TelemetryCode, updateSmartContainer.Id);

            return Ok(new SmartContainerResponse<SmartContainer>(updateSmartContainer, "Data Updated Successfully."));
        }

        [HttpDelete(SmartContainerRoute.SmsrtContainer.DeleteSmsrtContainer)]
        public async Task<IActionResult> DeleteSmartContainer(int id)
        {
            var deleteSmartContainer = await _service.DeleteSmartContainerById(id);
            if (!deleteSmartContainer)
            {
                _logger.LogWarning("Container Id {Id} not found for soft Delete", id);
                return NotFound(new SmartContainerResponse<SmartContainer>("Given Id of Smart Container Not Found."));
            }

            _logger.LogInformation("Container {Id} soft deleted", id);
            return NoContent();
        }
    }
}