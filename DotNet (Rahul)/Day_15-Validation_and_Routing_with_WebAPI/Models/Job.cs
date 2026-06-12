namespace Day_15_Validation_and_Routing_with_WebAPI.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Company { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string JobType { get; set; } = null!;
        public decimal Salary { get; set; }
        public DateTime PostDate { get; set; }
        public bool IsActive { get; set; }
    }
}
