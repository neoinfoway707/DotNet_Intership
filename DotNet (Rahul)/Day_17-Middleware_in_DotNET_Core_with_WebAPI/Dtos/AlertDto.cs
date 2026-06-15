using System.ComponentModel.DataAnnotations;

namespace Day_17_Middleware_in_DotNET_Core_with_WebAPI.Dtos
{
    public class AlertDto
    {
        [Required(ErrorMessage = "Alert title is required.")]
        [StringLength(100, ErrorMessage = "Title must be between 3 and 100 characters.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Alert message is required.")]
        [StringLength(1000, ErrorMessage = "Message cannot exceed 1000 characters.")]
        public string Message { get; set; } = null!;

        [Required(ErrorMessage = "Severity level is required.")]
        [RegularExpression("^(Info|Warning|Error|Critical)$",
            ErrorMessage = "Invalid Severity. Allowed values: Info, Warning, Error, Critical.")]
        public string Severity { get; set; } = null!;

        [Required(ErrorMessage = "Source is required.")]
        [StringLength(150, ErrorMessage = "Source system name cannot exceed 150 characters.")]
        public string Source { get; set; } = null!;

        [Required(ErrorMessage = "Resolution status flag is required.")]
        public bool IsResolved { get; set; }
    }
}
