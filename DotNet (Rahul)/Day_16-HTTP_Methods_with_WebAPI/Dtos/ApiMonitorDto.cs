using System.ComponentModel.DataAnnotations;

namespace Day_16_HTTP_Methods_with_WebAPI.Dtos
{
    public class ApiMonitorDto
    {
        [Required(ErrorMessage = "Endpoint URL is required.")]
        [Url(ErrorMessage = "Please provide a valid absolute URL (e.g., https://example.com).")]
        [StringLength(500, ErrorMessage = "Endpoint URL cannot exceed 500 characters.")]
        public string EndpointUrl { get; set; } = null!;

        [Required(ErrorMessage = "HTTP Method is required.")]
        [RegularExpression("^(GET|POST|PUT|DELETE|PATCH|HEAD|OPTIONS)$",
            ErrorMessage = "Invalid HTTP Method. Allowed methods: GET, POST, PUT, DELETE, PATCH, HEAD, OPTIONS.")]
        public string Method { get; set; } = null!;

        [Required(ErrorMessage = "Expected status code is required.")]
        [Range(100, 599, ErrorMessage = "Expected Status Code must be a valid HTTP standard code between 100 and 599.")]
        public int ExpectedStatusCode { get; set; }

        [Required(ErrorMessage = "Environment status flag is required.")]
        public bool IsEnvironmentProduction { get; set; }
    }
}
