using Day_19_Working_with_EF_Core_in_WebAPI.Dtos;
using Day_19_Working_with_EF_Core_in_WebAPI.Models;
using Day_19_Working_with_EF_Core_in_WebAPI.Services;
using Day_19_Working_with_EF_Core_in_WebAPI.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace Day_19_Working_with_EF_Core_in_WebAPI.Controllers
{
    [ApiController]
    public class SmartContainerController(ISmartContainerServices _service) : ControllerBase
    {
        [HttpGet(SmartContainerRoute.SmsrtContainer.GetAllSmsrtContainer)]
        public async Task<IActionResult> GetAllSmartContainer()
        {
            var listOfAllSmartContainer = await _service.GetAllSmartContainers();
            return Ok(new SmartContainerResponse<List<SmartContainer>>(listOfAllSmartContainer, "Data Retrieved Successfully."));
        }

        [HttpGet(SmartContainerRoute.SmsrtContainer.GetSmsrtContainerById)]
        public async Task<IActionResult> GetSmartContainerById(int id)
        {
            var getSmartContainer = await _service.GetSmartContainerById(id);
            if (getSmartContainer == null)
                return NotFound(new SmartContainerResponse<SmartContainer>("Given Id of Smart Container Not Found."));

            return Ok(new SmartContainerResponse<SmartContainer>(getSmartContainer, "Data Retrieved Successfully."));
        }

        [HttpPost(SmartContainerRoute.SmsrtContainer.CreateSmsrtContainer)]
        public async Task<IActionResult> CreateSmartContainer(SmartContainerDto containerDto)
        {
            var addSmartContainer = await _service.CreateSmartContainer(containerDto);
            var wrapperClass = new SmartContainerResponse<SmartContainer>(addSmartContainer, "SmartContainer Created Successfully.");
            return CreatedAtAction(nameof(GetSmartContainerById), new { Id = addSmartContainer.Id }, wrapperClass);
        }

        [HttpPut(SmartContainerRoute.SmsrtContainer.UpdateSmsrtContainer)]
        public async Task<IActionResult> UpdateSmartContainer(int id, SmartContainerDto containerDto)
        {
            var updateSmartContainer = await _service.UpdateSmartContainer(id, containerDto);
            
            if(updateSmartContainer == null)
                return NotFound(new SmartContainerResponse<SmartContainer>("Given Id of Smart Container Not Found."));

            return Ok(new SmartContainerResponse<SmartContainer>(updateSmartContainer, "Data Updated Successfully."));
        }

        [HttpDelete(SmartContainerRoute.SmsrtContainer.DeleteSmsrtContainer)]
        public async Task<IActionResult> DeleteSmartContainer(int id)
        {
            var deleteSmartContainer = await _service.DeleteSmartContainerById(id);
            if(!deleteSmartContainer)
                return NotFound(new SmartContainerResponse<SmartContainer>("Given Id of Smart Container Not Found."));

            return NoContent();
        }
    }
}