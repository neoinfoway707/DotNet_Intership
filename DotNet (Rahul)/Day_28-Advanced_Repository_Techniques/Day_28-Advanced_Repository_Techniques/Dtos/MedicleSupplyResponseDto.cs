namespace Day_28_Advanced_Repository_Techniques.Dtos
{
    public class MedicleSupplyResponseDto
    {
        public int Id { get; set; }
        public string ItemCode { get; set; } = null!;
        public string ItemName { get; set; } = null!;
        public string Category { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
