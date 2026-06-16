using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_19_Working_with_EF_Core_in_WebAPI.Models
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
