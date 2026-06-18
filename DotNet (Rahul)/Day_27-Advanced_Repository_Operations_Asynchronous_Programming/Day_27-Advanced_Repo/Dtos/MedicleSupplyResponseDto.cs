namespace Day_27_Advanced_Repository_Operations_Asynchronous_Programming.Dtos
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
