using System.ComponentModel.DataAnnotations;

namespace Day_10_Database_First_Approach.Models;

public partial class Customer
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Customer name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = null!;

    [Required(ErrorMessage = "Email address is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    [StringLength(150)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Phone number must be between 10 to 15 digits long and can optionally start with '+'.")]
    [StringLength(20)]
    public string Phone { get; set; } = null!;
}
