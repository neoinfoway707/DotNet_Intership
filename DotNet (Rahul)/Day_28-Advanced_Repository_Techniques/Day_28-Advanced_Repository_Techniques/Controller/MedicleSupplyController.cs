using Day_28_Advanced_Repository_Techniques.Const;
using Day_28_Advanced_Repository_Techniques.Dtos;
using Day_28_Advanced_Repository_Techniques.Repositories;
using Day_28_Advanced_Repository_Techniques.Validation;
using Day_28_Advanced_Repository_Techniques.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace Day_28_Advanced_Repository_Techniques.Controller
{
    [ApiController]
    public class MedicleSupplyController(IMedicleSupplyRepository _repo, ILogger<MedicleSupplyController> _logger) : ControllerBase
    {
        [HttpGet(MedicleSupplyRoute.MedicleSupply.GetAllMedicleSupplys)]
        public async Task<IActionResult> GetAllMedicleSupplys([FromQuery] MedicleSupplyQueryParams queryParams)
        {
            var (items, totalCount) = await _repo.GetallMedicleSupplysAsync(queryParams);
            var response = new MedicleSupplyPageResponse<List<MedicleSupplyResponseDto>>(items,
                "All MedicleSupply Data Retrieved successfully.", queryParams.Pages,
                queryParams.PageSize, totalCount);

            _logger.LogInformation("Fetching all active MedicleSupply data. Page {Page} of {TotalPages}",
                  queryParams.Pages, response.TotalPages);
            
            return Ok(response);
        }

        [HttpGet(MedicleSupplyRoute.MedicleSupply.GetMedicleSupplyByID)]
        public async Task<IActionResult> GetMedicleSupplyById(int id)
        {
            var getMedicleSupply = await _repo.GetMedicleSupplyIdAsync(id);
            if (getMedicleSupply == null)
            {
                _logger.LogWarning("MedicleSupply with Id {Id} not found.", id);
                return NotFound(new MedicleSupplyResponse<MedicleSupplyResponseDto>($"MedicleSupply with Id {id} not found."));
            }
            _logger.LogInformation("Fetching MedicleSupply with Id {Id}", id);
            return Ok(new MedicleSupplyResponse<MedicleSupplyResponseDto>(getMedicleSupply, "Data Retrieved Successfully."));
        }
        [ExpiryDateValidationActionFilter]
        [HttpPost(MedicleSupplyRoute.MedicleSupply.CreateMedicleSupply)]
        public async Task<IActionResult> CreateMedicleSupply(MedicleSupplyRequestDto requestDto)
        {
            var addMedicleSupply = await _repo.CreateMedicleSupplyAsync(requestDto);
            var wrapperResponse = new MedicleSupplyResponse<MedicleSupplyResponseDto>(addMedicleSupply, "New MedicleSupply Created.");
            _logger.LogInformation("MedicleSupply {Name} created with Id {Id}.", addMedicleSupply.ItemName, addMedicleSupply.Id);
            return CreatedAtAction(nameof(GetMedicleSupplyById), new { Id = addMedicleSupply.Id }, wrapperResponse);
        }

        [ExpiryDateValidationActionFilter]
        [HttpPut(MedicleSupplyRoute.MedicleSupply.UpdateMedicleSupply)]
        public async Task<IActionResult> UpdateMedicleSupply(int id, MedicleSupplyRequestDto requestDto)
        {
            var updateMedicleSupply = await _repo.UpdateMedicleSupplyAsync(id, requestDto);
            if (updateMedicleSupply == null)
            {
                _logger.LogWarning("MedicleSupply with Id {Id} not found.", id);
                return NotFound(new MedicleSupplyResponse<MedicleSupplyResponseDto>($"MedicleSupply with Id {id} not found."));
            }
            _logger.LogInformation("MedicleSupply {Name} Updated with Id {Id}", updateMedicleSupply.ItemName, updateMedicleSupply.Id);
            return Ok(new MedicleSupplyResponse<MedicleSupplyResponseDto>(updateMedicleSupply, "MedicleSupply Data Updated Successfully."));
        }

        [HttpDelete(MedicleSupplyRoute.MedicleSupply.DeleteMedicleSupply)]
        public async Task<IActionResult> DeleteMedicleSupply(int id)
        {
            var deleteMedicleSupply = await _repo.DeleteMedicleSupplyAsync(id);
            if (!deleteMedicleSupply)
            {
                _logger.LogWarning("MedicleSupply with Id {Id} not found.", id);
                return NotFound(new MedicleSupplyResponse<MedicleSupplyResponseDto>($"MedicleSupply with Id {id} not found."));
            }
            _logger.LogInformation("MedicleSupply with Id {Id} is marked as Deleted at Database side.", id);
            return NoContent();
        }
    }
}