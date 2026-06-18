using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_26_DI_Testing_in_Dot_NET_Core.Models
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }
        public string BusinessName { get; set; } = null!;
        public string TaxId { get; set; } = null!;
        public string ContactEmail { get; set; } = null!;
        [Column(TypeName = "decimal(18,2)")]
        public decimal CreditLimit { get; set; }
        public string PaymentTerms { get; set; } = null!;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime OnboardedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}