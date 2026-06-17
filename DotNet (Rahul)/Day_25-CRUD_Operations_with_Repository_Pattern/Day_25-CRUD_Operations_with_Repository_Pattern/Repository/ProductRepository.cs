using Day_25_CRUD_Operations_with_Repository_Pattern.Data;
using Day_25_CRUD_Operations_with_Repository_Pattern.Dtos;
using Day_25_CRUD_Operations_with_Repository_Pattern.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Day_25_CRUD_Operations_with_Repository_Pattern.Repository
{
    public class ProductRepository(AppDbContext _context, ILogger<ProductRepository> _logger) : IProductRepository
    {
        public async Task<List<ProductResponseDto>> GetAllProductsAsync()
        {
            _logger.LogInformation("Querying Database for all active product");
            var listOfProducts = await _context.Products.Where(p => !p.IsDelete).ToListAsync();
            var products = ProductMapper.ToDtoList(listOfProducts);
            return products;
        }

        public async Task<ProductResponseDto?> GetProductByIdAsync(int id)
        {
            _logger.LogInformation("Querying database for active product Id {Id}", id);
            var getProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDelete);
            if (getProduct == null)
            {
                _logger.LogWarning("Product Id {Id} not found in database", id);
                return null;
            }
            var productResponse = ProductMapper.ToDto(getProduct);
            return productResponse;
        }

        public async Task<ProductResponseDto> CreateProductAsync(ProductRequestDto requestDto)
        {
            var product = ProductMapper.ToProduct(requestDto);

            _logger.LogInformation("Saving a new Product {Name} to database.", product.Name);

            using var trans = await _context.Database.BeginTransactionAsync();
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            await trans.CommitAsync();

            _logger.LogInformation("Product {Name} saving with Id {Id}", product.Name, product.Id);
            return ProductMapper.ToDto(product);
        }

        public async Task<ProductResponseDto?> UpdateProductAsync(int id, ProductRequestDto requestDto)
        {
            _logger.LogInformation("Querying database to update Prodcut with Id {Id}", id);
            var getProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (getProduct == null)
            {
                _logger.LogWarning("Product Id {Id} not found in database", id);
                return null;
            }

            using var trans = await _context.Database.BeginTransactionAsync();
            getProduct.Name = requestDto.Name;
            getProduct.Sku = requestDto.Sku;
            getProduct.Price = requestDto.Price;
            getProduct.Stock = requestDto.Stock;
            getProduct.ReorderLevel = requestDto.ReorderLevel;
            getProduct.IsActive = requestDto.IsActive;

            await _context.SaveChangesAsync();
            await trans.CommitAsync();

            _logger.LogInformation("Product Id {Id} Updated Successfully", getProduct.Id);
            return ProductMapper.ToDto(getProduct);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            _logger.LogInformation("Querying database to soft delete Prodcut with Id {Id}", id);

            var getProduct = _context.Products.FirstOrDefault(x => x.Id == id);
            if (getProduct == null)
            {
                _logger.LogWarning("Product Id {Id} not found in database", id);
                return false;
            }

            using var trans = await _context.Database.BeginTransactionAsync();
            getProduct.IsDelete = true;
            await _context.SaveChangesAsync();
            await trans.CommitAsync();

            _logger.LogInformation("Product Id {Id} marked as deleted in database.", getProduct.Id);
            return true;
        }
    }
}