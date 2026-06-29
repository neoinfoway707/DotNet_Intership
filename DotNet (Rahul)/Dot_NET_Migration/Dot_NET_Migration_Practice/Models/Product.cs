using System.ComponentModel.DataAnnotations;

namespace Dot_NET_Migration_Practice.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [StringLength(20)]
        public string SKU { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
