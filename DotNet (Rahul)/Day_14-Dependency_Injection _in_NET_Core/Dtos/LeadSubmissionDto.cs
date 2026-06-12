using System.ComponentModel.DataAnnotations;

namespace Day_14_Dependency_Injection__in_NET_Core.Dtos
{
    public class LeadSubmissionDto
    {
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, ErrorMessage = "Full name must be between 3 and 100 characters.")]

        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Email address is required.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Requirements cannot be empty.")]
        [StringLength(1000, ErrorMessage = "Requirements cannot exceed 1000 characters.")]
        public string Requirements { get; set; } = null!;

        [Required(ErrorMessage = "Budget is required.")]
        [Range(100, 100000, ErrorMessage = "Budget must be between 100 and 100,000.")]
        public decimal Budget { get; set; }
    }
}
