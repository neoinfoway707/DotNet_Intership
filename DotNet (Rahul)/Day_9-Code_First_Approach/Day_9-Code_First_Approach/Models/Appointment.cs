using System.ComponentModel.DataAnnotations;

namespace Day_9_Code_First_Approach.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Patient name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Patient name must be between 2 and 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Patient name cannot contain numbers.")]
        public string PatientName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Appointment time is required.")]
        [DataType(DataType.DateTime)]
        public DateTime? AppointmentTime { get; set; }

        [Required(ErrorMessage = "Reason for appointment is required.")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Reason must be between 5 and 500 characters.")]
        public string Reason { get; set; } = string.Empty;

        [Required(ErrorMessage = "Doctor Selection is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Doctor.")]
        [Display(Name = "Doctor Name")]
        public int DoctorId { get; set; }

    }
}
