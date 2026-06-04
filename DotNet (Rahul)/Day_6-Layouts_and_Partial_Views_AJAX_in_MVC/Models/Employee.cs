using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_6_Layouts_and_Partial_Views_AJAX_in_MVC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        [StringLength(50, ErrorMessage = "Name must be 50 characters")]
        [Display(Name = "Employee Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department is required")]
        [StringLength(50, ErrorMessage = "Department must be 50 characters")]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Designation is required")]
        [StringLength(50, ErrorMessage = "Designation must be 50 characters")]
        public string Designation { get; set; } = string.Empty;

        [Required(ErrorMessage = "Joining date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Salary is required")]
        [Range(10000, 1000000, ErrorMessage = "Salary must be between 10,000 and 10,000,000")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Monthly Salary")]
        public decimal Salary { get; set; }

    }
}
