using System.ComponentModel.DataAnnotations;

namespace Day_4_Forms_and_Validation_in_MVC.Models
{
    public class User
    {
        //Create a class User with the following properties: Id, Name, Age, Email, Password, and ConfirmPassword. with appropriate data types and validation attributes.
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name cannot be longer than 50 characters")]
        [DataType(DataType.Text)]
        [Display(Name = "Enter Full Name : ")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 25, ErrorMessage = "Age must be between 18 and 25")]
        [Display(Name = "Enter Age : ")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email Address format")]
        [Display(Name = "Enter Email : ")]
        public string? Email { get; set; }
       
        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 16 characters long")]
        [DataType(DataType.Password)]
        [Display(Name = "Enter Password : ")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password : ")]
        public string? ConfirmPassword { get; set; }
    }
}
