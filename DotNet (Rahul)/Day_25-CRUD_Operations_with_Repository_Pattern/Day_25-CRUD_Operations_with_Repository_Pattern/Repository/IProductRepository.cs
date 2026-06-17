using Day_25_CRUD_Operations_with_Repository_Pattern.Dtos;

namespace Day_25_CRUD_Operations_with_Repository_Pattern.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductResponseDto>> GetAllProductsAsync();
        Task<ProductResponseDto?> GetProductByIdAsync(int id);
        Task<ProductResponseDto> CreateProductAsync(ProductRequestDto requestDto);
        Task<ProductResponseDto?> UpdateProductAsync(int id, ProductRequestDto requestDto);
        Task<bool> DeleteProductAsync(int id);
    }
}
