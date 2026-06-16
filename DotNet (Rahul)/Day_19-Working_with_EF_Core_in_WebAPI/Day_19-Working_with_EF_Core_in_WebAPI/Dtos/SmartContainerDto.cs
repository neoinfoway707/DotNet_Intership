using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_19_Working_with_EF_Core_in_WebAPI.Dtos
{
    public class SmartContainerDto
    {
        [Required(ErrorMessage = "Telemetry Code is required.")]
        [RegularExpression(@"^CON-[A-Z]{3}-\d{4}$", ErrorMessage = "Telemetry Code must follow format: CON-XYZ-1234")]
        [StringLength(12, ErrorMessage = "Telemetry Code cannot exceed 12 characters.")]
        public string TelemetryCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Current temperature is required.")]
        [Range(-30.0, 50.0, ErrorMessage = "Temperature must be between -30°C and 50°C.")]
        [Column(TypeName = "decimal(4,2)")]
        public decimal CurrentTemperature { get; set; }

        [Required(ErrorMessage = "Humidity percentage is required.")]
        [Range(0, 100, ErrorMessage = "Humidity percentage must be between 0 and 100.")]
        public int HumidityPercentage { get; set; }

        [Required(ErrorMessage = "Destination port is required.")]
        [StringLength(100, ErrorMessage = "Destination Port name must be between 3 and 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s,.-]+$", ErrorMessage = "Destination Port can only contain letters, spaces, hyphens, periods, or commas.")]
        public string DestinationPort { get; set; } = string.Empty;
    }
}
