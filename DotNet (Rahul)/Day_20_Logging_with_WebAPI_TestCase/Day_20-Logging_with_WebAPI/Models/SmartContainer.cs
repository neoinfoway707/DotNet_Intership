using System.ComponentModel.DataAnnotations.Schema;

namespace Day_20_Logging_with_WebAPI.Models
{
    public class SmartContainer
    {
        public int Id { get; set; }
        public string TelemetryCode { get; set; } = string.Empty;
        [Column(TypeName = "decimal(4,2)")]
        public decimal CurrentTemperature { get; set; }
        public int HumidityPercentage { get; set; }
        public string DestinationPort { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
