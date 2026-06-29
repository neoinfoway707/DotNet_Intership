using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task<bool> CreateUpdateProduct(string operation, Product product, int? id = null);
        Task<bool> DeleteProduct(int id);

    }
}