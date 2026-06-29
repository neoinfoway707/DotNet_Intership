using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Data;
using System.Runtime.CompilerServices;

namespace ProductManagement.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext _context, ILogger<ProductRepository> _logger) : IProductRepository
    {
        public async Task<List<Product>> GetAllProducts()
        {
            _logger.LogInformation("Querying Database for all active Products");
            var listOfProducts = await _context.Products.Where(p => !p.IsDeleted).ToListAsync();
            return listOfProducts;
        }

        public async Task<Product?> GetProductById(int id)
        {
            _logger.LogInformation("Querying database for active Product Id {Id}", id);

            var getProduct = await _context.Products
                .Where(p => p.Id == id && !p.IsDeleted)
                .FirstOrDefaultAsync();

            //var getProduct = await _context.Products
            //    .FromSqlRaw("SELECT * FROM Products WHERE Id=@id", new SqlParameter("@id", id))
            //    .FirstOrDefaultAsync();

            //var getProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (getProduct == null)
            {
                _logger.LogWarning("Product Id {Id} not found in database", id);
                return null;
            }
            return getProduct;
        }
        public async Task<bool> CreateUpdateProduct(string operation, Product product, int? id = null)
        {
            if (operation.ToLower() == "insert" && id == null)
            {
                _logger.LogInformation("Saving a new Product {Name} to database.", product.Name);
                try
                {
                    using var trans = await _context.Database.BeginTransactionAsync();

                    await _context.Products.AddAsync(product);
                    await _context.SaveChangesAsync();
                    await trans.CommitAsync();
                    _logger.LogInformation("Product {Name} saving with Id {Id}", product.Name, product.Id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to create Product {Title}", product.Name);
                    throw;
                }
            }
            else if (operation.ToLower() == "update" && id != null)
            {
                _logger.LogInformation("Querying database to update Product with Id {Id}", id);

                var getProduct = await _context.Products
                    .Where(p => p.Id == id && !p.IsDeleted)
                    .FirstOrDefaultAsync();

                if (getProduct == null)
                {
                    _logger.LogWarning("Product Id {Id} not found in database", id);
                    return false;
                }

                try
                {
                    using var trans = await _context.Database.BeginTransactionAsync();
                    _context.Entry(getProduct).CurrentValues.SetValues(product);

                    if (string.IsNullOrEmpty(product.ImagePath))
                        _context.Entry(getProduct).Property(p => p.ImagePath).IsModified = false;

                    _context.Entry(getProduct).Property(p => p.CreatedAt).IsModified = false;
                    _context.Entry(getProduct).Property(p => p.IsDeleted).IsModified = false;

                    await _context.SaveChangesAsync();
                    await trans.CommitAsync();

                    _logger.LogInformation("Product Id {Id} Updated Successfully", getProduct.Id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to Update Product {Title}", getProduct.Name);
                    throw;
                }
            }
            else
            {
                _logger.LogError("Failed to execute {name} command ", operation);
                return false;
            }
            return true;
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var getProduct = await _context.Products
               .Where(p => p.Id == id && !p.IsDeleted)
               .FirstOrDefaultAsync();

            if (getProduct == null)
            {
                _logger.LogWarning("Product Id {Id} not found in database", id);
                return false;
            }
            try
            {
                using var trans = await _context.Database.BeginTransactionAsync();
                getProduct.IsDeleted = true;
                await _context.SaveChangesAsync();
                await trans.CommitAsync();

                _logger.LogInformation("Product Id {Id} marked as deleted in database.", getProduct.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Deleye Product {Title}", getProduct.Id);
                throw;
            }
        }
    }
}