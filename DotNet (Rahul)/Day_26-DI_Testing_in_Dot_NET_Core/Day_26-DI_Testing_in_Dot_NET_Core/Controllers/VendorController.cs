using Day_26_DI_Testing_in_Dot_NET_Core.Const;
using Day_26_DI_Testing_in_Dot_NET_Core.Dtos;
using Day_26_DI_Testing_in_Dot_NET_Core.Repositories;
using Day_26_DI_Testing_in_Dot_NET_Core.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_26_DI_Testing_in_Dot_NET_Core.Controllers
{
    [ApiController]
    public class VendorController(IVendorRepository _repo, ILogger<VendorController> _logger) : ControllerBase
    {
        [HttpGet(VendorRoute.Vendor.GetAllVendors)]
        public async Task<IActionResult> GetAllVendors()
        {
            var listOfVendors = await _repo.GetallVendorsAsync();
            var wrapperResponse = new VendorResponse<List<VendorResponseDto>>(listOfVendors, "All Vendor Data Retrieved successfully.");
            _logger.LogInformation("Fetching all active Vendor data.");
            return Ok(wrapperResponse);
        }

        [HttpGet(VendorRoute.Vendor.GetVendorById)]
        public async Task<IActionResult> GetVendorById(int id)
        {
            var getVendor = await _repo.GetVendroByIdAsync(id);
            if (getVendor == null)
            {
                _logger.LogWarning("Vendor with Id {Id} not found.", id);
                return NotFound(new VendorResponse<VendorResponseDto>($"Vendor with Id {id} not found."));
            }
            _logger.LogInformation("Fetching Vendor with Id {Id}", id);
            return Ok(new VendorResponse<VendorResponseDto>(getVendor, "Data Retrieved Successfully."));
        }
        [HttpPost(VendorRoute.Vendor.CreateVendor)]
        public async Task<IActionResult> CreateVendor(VendorRequestDto requestDto)
        {
            var addVendor = await _repo.CreateVendorAsync(requestDto);
            var wrapperResponse = new VendorResponse<VendorResponseDto>(addVendor, "New Vendor Created.");
            _logger.LogInformation("Vendor {Name} created with Id {Id}.", addVendor.BusinessName, addVendor.Id);
            return CreatedAtAction(nameof(GetVendorById), new { Id = addVendor.Id }, wrapperResponse);
        }

        [HttpPut(VendorRoute.Vendor.UpdateVendor)]
        public async Task<IActionResult> UpdateVendor(int id, VendorRequestDto requestDto)
        {
            var updateVendor = await _repo.UpdateVendorAsync(id, requestDto);
            if (updateVendor == null)
            {
                _logger.LogWarning("Vendor with Id {Id} not found.", id);
                return NotFound(new VendorResponse<VendorResponseDto>($"Vendor with Id {id} not found."));
            }
            _logger.LogInformation("Vendor {Name} Updated with Id {Id}", updateVendor.BusinessName, updateVendor.Id);
            return Ok(new VendorResponse<VendorResponseDto>(updateVendor, "Vendor Data Updated Successfully."));
        }

        [HttpDelete(VendorRoute.Vendor.DeleteVendor)]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            var deleteVendor = await _repo.DeleteVendorAsync(id);
            if (!deleteVendor)
            {
                _logger.LogWarning("Vendor with Id {Id} not found.", id);
                return NotFound(new VendorResponse<VendorResponseDto>($"Vendor with Id {id} not found."));
            }
            _logger.LogInformation("Vendor with Id {Id} is marked as Deleted at Database side.", id);
            return NoContent();
        }
    }
}