using System.ComponentModel.DataAnnotations;

namespace Day_28_Advanced_Repository_Techniques.Dtos
{
    public class MedicleSupplyRequestDto
    {
        [Required(ErrorMessage = "Item code is required.")]
        [RegularExpression(@"^MED-\d{4}$", ErrorMessage = "Item Code must follow the format: MED-1234")]
        [StringLength(8, ErrorMessage = "Item Code cannot exceed 8 characters.")]
        public string ItemCode { get; set; } = null!;

        [Required(ErrorMessage = "Item name is required.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Item name must be between 2 and 150 characters.")]
        public string ItemName { get; set; } = null!;

        [Required(ErrorMessage = "Category is required.")]
        [RegularExpression("^(Surgical|Diagnostic|Pharmaceutical)$",
            ErrorMessage = "Category must be either 'Surgical', 'Diagnostic', or 'Pharmaceutical'.")]
        [StringLength(30, ErrorMessage = "Category name cannot exceed 30 characters.")]
        public string Category { get; set; } = null!;

        [Required(ErrorMessage = "Unit price is required.")]
        [Range(0.01, 100000.00, ErrorMessage = "Unit price must be a positive value between 0.01 and 100,000.00.")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Quantity in stock is required.")]
        [Range(0, 1000000, ErrorMessage = "Quantity in stock cannot be negative.")]
        public int QuantityInStock { get; set; }

        [Required(ErrorMessage = "Expiry date is required.")]
        public DateTime ExpiryDate { get; set; }
    }
}
