using Day_18_Authentication_and_Authorization_in_Web_APIs.Dtos;
using Day_18_Authentication_and_Authorization_in_Web_APIs.Models;

namespace Day_18_Authentication_and_Authorization_in_Web_APIs.Services
{
    public interface ICodeReviewService
    {
        List<CodeReviewSession> GetAllCodeReview();
        CodeReviewSession? GetCodeReviewById(int id);
        CodeReviewSession CreateCodeReview(CodeReviewDto codeReviewDto);
        CodeReviewSession? UpdateCodeReview(int id, CodeReviewDto codeReviewDto);
        bool DeleteCodeReview(int id);

    }
}
