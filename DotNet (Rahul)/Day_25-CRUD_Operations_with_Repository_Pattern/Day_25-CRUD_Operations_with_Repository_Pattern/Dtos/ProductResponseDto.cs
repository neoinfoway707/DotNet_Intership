using System.ComponentModel.DataAnnotations.Schema;

namespace Day_25_CRUD_Operations_with_Repository_Pattern.Dtos
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int ReorderLevel { get; set; } = 10;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
    }
}
