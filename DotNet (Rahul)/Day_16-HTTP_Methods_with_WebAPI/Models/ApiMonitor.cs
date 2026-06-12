namespace Day_16_HTTP_Methods_with_WebAPI.Models
{
    public class ApiMonitor
    {
        public int Id { get; set; }
        public string EndpointUrl { get; set; } = null!;
        public string Method { get; set; } = null!;
        public int ExpectedStatusCode { get; set; }
        public bool IsEnvironmentProduction { get; set; }
    }
}
