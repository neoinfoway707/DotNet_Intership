using System.ComponentModel.DataAnnotations;

namespace Day_18_Authentication_and_Authorization_in_Web_APIs.Dtos
{
    public class CodeReviewDto
    {
        [Required(ErrorMessage = "Repository name is required.")]
        [StringLength(100, ErrorMessage = "Repository name must be between 3 and 100 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9._-]+$", ErrorMessage = "Repository name can only contain alphanumeric characters, dots, underscores, or hyphens.")]
        public string RepositoryName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Branch name is required.")]
        [StringLength(100, ErrorMessage = "Branch name cannot exceed 100 characters.")]
        public string BranchName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quality score is required.")]
        [Range(0.0, 100.0, ErrorMessage = "Quality score must be a percentage between 0.0 and 100.0.")]
        public double QualityScore { get; set; }

        [Required(ErrorMessage = "Issues count is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Issues count cannot be a negative number.")]
        public int IssuesCount { get; set; }

        [Required(ErrorMessage = "Review status is required.")]
        [RegularExpression("^(Pending|UnderReview|Approved|Rejected)$",
            ErrorMessage = "Invalid Status. Allowed values: Pending, UnderReview, Approved, Rejected.")]
        public string ReviewStatus { get; set; } = "Pending";
    }
}
