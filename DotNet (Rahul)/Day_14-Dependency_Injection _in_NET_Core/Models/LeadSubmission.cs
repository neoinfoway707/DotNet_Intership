namespace Day_14_Dependency_Injection__in_NET_Core.Models
{
    public class LeadSubmission
    {
        public int LeadId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Requirements { get; set; } = null!;
        public decimal Budget { get; set; }
    }
}
