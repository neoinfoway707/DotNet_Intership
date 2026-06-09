namespace Day_9_Code_First_Approach.Models
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string? PatientName { get; set; }
        public DateTime? AppointmentTime { get; set; }
        public string? Reason { get; set; }
        public int DoctorId { get; set; }
        public Doctor doctor { get; set; }
    }
}