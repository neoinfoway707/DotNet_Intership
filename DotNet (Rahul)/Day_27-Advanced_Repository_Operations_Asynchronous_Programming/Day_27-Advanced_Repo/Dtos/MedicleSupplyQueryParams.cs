using System.ComponentModel.DataAnnotations;

namespace Day_27_Advanced_Repository_Operations_Asynchronous_Programming.Dtos
{
    public class MedicleSupplyQueryParams
    {
        public string? Category { get; set; }

        [Range(0.00, 100000.00, ErrorMessage = "Minimum price must be a non-negative value.")]
        public decimal? MinPrice { get; set; }
        [Range(0.00, 100000.00, ErrorMessage = "Maximum price must be a non-negative value.")]
        public decimal? MaxPrice { get; set; }

        [RegularExpression("^(unitprice|expirydate|quantityinstock)$", ErrorMessage = "You can only sort by 'unitprice', 'expirydate', or 'quantityinstock'.")]
        public string? SortBy { get; set; }

        [RegularExpression("^(asc|desc)$", ErrorMessage = "Sort order must be either 'asc' or 'desc'.")]
        public string SortOrder { get; set; } = "asc";

        [Range(1, 15, ErrorMessage = "Page number must be between 1 and 15.")]
        public int Pages { get; set; }
        [Range(1, 15, ErrorMessage = "Page size must be between 1 and 15 items per page.")]
        public int PageSize { get; set; }
    }
}
