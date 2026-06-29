using System.ComponentModel.DataAnnotations;

namespace Dot_NET_Migration_Practice.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string? Title { get; set; }
        [Required]
        public string? PostContent { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsPublished { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
