using System.ComponentModel.DataAnnotations;

namespace Day_9_Code_First_Approach.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Doctor name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Doctor name must be between 2 and 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Doctor name cannot contain numbers")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Specialization is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Specialization must be between 3 and 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Specialization cannot contain numbers.")]
        public string Specialization { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid 10-digit phone number.")]
        public string Phone { get; set; } = string.Empty;
    }
}