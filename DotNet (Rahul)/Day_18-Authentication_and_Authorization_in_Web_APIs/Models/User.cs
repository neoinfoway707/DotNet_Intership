using System.ComponentModel.DataAnnotations;

namespace Day_18_Authentication_and_Authorization_in_Web_APIs.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role assignment is required.")]
        [RegularExpression("^(Admin|Developer)$", ErrorMessage = "Role must be either 'Admin' or 'Developer'.")]
        public string Role { get; set; } = "Developer";
    }
}
