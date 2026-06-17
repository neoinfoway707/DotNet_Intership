using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_25_CRUD_Operations_with_Repository_Pattern.Dtos
{
    public class ProductRequestDto
    {
        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "SKU is required.")]
        [RegularExpression(@"^[A-Z]{3}-\d{4}$", ErrorMessage = "SKU format must match ABC-1234.")]
        public string Sku { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 50000.00, ErrorMessage = "Price must be between 0.01 and 50,000.00.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
        public int Stock { get; set; }

        [Range(1, 100, ErrorMessage = "Reorder level must be at least 1.")]
        public int ReorderLevel { get; set; } = 10;

        public bool IsActive { get; set; } = true;
    }
}
