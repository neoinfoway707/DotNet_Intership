using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductManagement.Application.Common.Dtos;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Mappers;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Data;
using System.Collections;
using System.Diagnostics;

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
            var getProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (getProduct == null)
            {
                _logger.LogWarning("Product Id {Id} not found in database", id);
                return null;
            }
            return getProduct;
        }

        public async Task CreateProduct(Product product)
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

        public async Task<bool> UpdateProduct(int id, Product product)
        {
            _logger.LogInformation("Querying database to update Product with Id {Id}", id);

            // 1. Fetch the tracked entity from the database
            var getProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
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
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Update Product {Title}", getProduct.Name);
                throw;
            }
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var getProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
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