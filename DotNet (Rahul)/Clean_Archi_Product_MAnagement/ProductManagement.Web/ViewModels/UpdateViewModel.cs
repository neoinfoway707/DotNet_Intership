using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Web.ViewModels
{
    public class UpdateViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [Display(Name = "Product Name")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "SKU is required.")]
        [StringLength(50, ErrorMessage = "SKU cannot exceed 50 characters.")]
        [Display(Name = "Stock Keeping Unit (SKU)")]
        public string Sku { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 100000.00, ErrorMessage = "Price must be between 0.01 and 100,000.00.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be a negative value.")]
        [Display(Name = "Stock Quantity")]
        public int Stock { get; set; }

        public string? ImagePath { get; set; }

        [Display(Name = "Product Image")]
        public IFormFile? ImageFile { get; set; }
    }
}