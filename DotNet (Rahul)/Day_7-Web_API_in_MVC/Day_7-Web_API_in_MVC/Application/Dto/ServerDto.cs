using System.ComponentModel.DataAnnotations;

namespace Day_7_Web_API_in_MVC.Application.Dto
{
    public class ServerDto
    {
        [Required(ErrorMessage = "Server name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Server name must be between {2} and {1} characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "IP Address is required.")]
        [RegularExpression(@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$",
              ErrorMessage = "Please enter a valid IPv4 address (e.g., 192.168.1.50).")]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "IP Address must be between {2} and {1} characters.")]
        public string IpAddress { get; set; } = null!;

        [Required(ErrorMessage = "RAM capacity is required.")]
        [Range(4, 512, ErrorMessage = "RAM capacity must be between {1} GB and {2} GB.")]
        public int RamGb { get; set; }

        [Required(ErrorMessage = "Server online status must be specified.")]
        public bool IsOnline { get; set; }
    }
}
