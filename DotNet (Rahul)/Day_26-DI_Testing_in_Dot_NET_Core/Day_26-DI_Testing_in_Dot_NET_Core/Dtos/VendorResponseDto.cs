namespace Day_26_DI_Testing_in_Dot_NET_Core.Dtos
{
    public class VendorResponseDto
    {
        public int Id { get; set; }
        public string BusinessName { get; set; } = null!;
        public string TaxId { get; set; } = null!;
        public string ContactEmail { get; set; } = null!;
        public decimal CreditLimit { get; set; }
        public string PaymentTerms { get; set; } = null!;
        public DateTime OnboardedAt { get; set; } = DateTime.UtcNow;
    }
}
