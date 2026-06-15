namespace Day_17_Middleware_in_DotNET_Core_with_WebAPI.Models
{
    public class Alert
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string Severity { get; set; } = null!;
        public string Source { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public bool IsResolved { get; set; }
    }
}
