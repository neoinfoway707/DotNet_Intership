using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_26_DI_Testing_in_Dot_NET_Core.Dtos
{
    public class VendorRequestDto
    {
        [Required(ErrorMessage = "Business name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Business name must be between 3 and 100 characters.")]
        public string BusinessName { get; set; } = null!;

        [Required(ErrorMessage = "Tax Identification Number (Tax ID) is required.")]
        [RegularExpression(@"^[A-Z]{4}\d{4}[A-Z]$", ErrorMessage = "Invalid Tax ID format. It must follow the enterprise pattern: 4 uppercase letters, 4 digits, and 1 uppercase letter (e.g., ABCD1234E).")]
        public string TaxId { get; set; } = null!;

        [Required(ErrorMessage = "Contact email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(150, ErrorMessage = "Email address cannot exceed 150 characters.")]
        public string ContactEmail { get; set; } = null!;

        [Required(ErrorMessage = "Credit limit is required.")]
        [Range(1000.00, 50000.00, ErrorMessage = "Credit limit must be between $1,000.00 and $50,000.00.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CreditLimit { get; set; }

        [Required(ErrorMessage = "Payment terms are required.")]
        [RegularExpression("^(Net15|Net30|Net45|Net60|DueOnReceipt)$",
            ErrorMessage = "Invalid payment terms. Allowed timelines: Net15, Net30, Net45, Net60, or DueOnReceipt.")]
        [StringLength(20, ErrorMessage = "Payment terms code cannot exceed 20 characters.")]
        public string PaymentTerms { get; set; } = null!;
    }
}