using System.ComponentModel.DataAnnotations;

namespace Day_13_Introduction_to_Web_APIs.Models
{
    public class VehicleDto
    {
       
        [Required(ErrorMessage = "Brand name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Brand must be between 2 and 50 characters.")]
        public string Brand { get; set; } = null!;

        [Required(ErrorMessage = "Model name is required.")]
        [StringLength(50, ErrorMessage = "Model cannot exceed 50 characters.")]
        public string Model { get; set; } = null!;

        [Required(ErrorMessage = "Year is required.")]
        [Range(1886, 2027, ErrorMessage = "Year must be between 1886 and next year.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 1000000000.00, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; }
    }
}
