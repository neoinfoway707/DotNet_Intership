using Day_18_Authentication_and_Authorization_in_Web_APIs.Dtos;
using Day_18_Authentication_and_Authorization_in_Web_APIs.Models;
using Day_18_Authentication_and_Authorization_in_Web_APIs.Services;
using Day_18_Authentication_and_Authorization_in_Web_APIs.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_18_Authentication_and_Authorization_in_Web_APIs.Controllers
{
    [ApiController]
    [Authorize]
    public class CodeReviewsController(ICodeReviewService _service) : ControllerBase
    {
        [HttpGet(CodeReviewRoute.CodeReview.GetAllCodeReview)]
        public IActionResult GetAllCodeReview()
        {
            //throw new Exception("Test exception for middleware");
            
            var listOfAllCodeReview = _service.GetAllCodeReview();
            return Ok(new CodeReviewResponse<List<CodeReviewSession>>(listOfAllCodeReview, "Data Retrieved Successfully."));
        }

        [HttpGet(CodeReviewRoute.CodeReview.GetCodeReviewById)]
        public IActionResult GetCodeReviewById(int id)
        {
            var get = _service.GetCodeReviewById(id);
            if (get == null)
                return NotFound(new CodeReviewResponse<CodeReviewSession>("Your given Id is not found."));
            return Ok(new CodeReviewResponse<CodeReviewSession>(get, "Data Retrieved Successfully."));
        }

        [HttpPost(CodeReviewRoute.CodeReview.CreateCodeReview)]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateCodeReview(CodeReviewDto codeReviewDto)
        {
            var addCodeReview = _service.CreateCodeReview(codeReviewDto);
            var wraperMessage = new CodeReviewResponse<CodeReviewSession>(addCodeReview, "Data Created Successfully.");

            return CreatedAtAction(nameof(GetCodeReviewById), new { Id = addCodeReview.Id }, wraperMessage);
        }

        [HttpPut(CodeReviewRoute.CodeReview.UpdateCodeReview)]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateCodeReviews(int id, CodeReviewDto codeReviewDto)
        {
            var updateCodeReview = _service.UpdateCodeReview(id, codeReviewDto);
            if (updateCodeReview == null)
                return NotFound(new CodeReviewResponse<CodeReviewSession>("Your given Id is not found."));

            return Ok(new CodeReviewResponse<CodeReviewSession>(updateCodeReview, "Data Updated Successfully."));
        }

        [HttpDelete(CodeReviewRoute.CodeReview.DeleteCodeReview)]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCodeReview(int id)
        {
            var deleteCodeReview = _service.DeleteCodeReview(id);
            if (!deleteCodeReview)
                return NotFound(new CodeReviewResponse<CodeReviewSession>("Your given Id is not found."));
            return NoContent();
        }
    }
}