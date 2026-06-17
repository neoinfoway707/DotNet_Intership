using Azure.Core;
using Day_25_CRUD_Operations_with_Repository_Pattern.Dtos;
using Day_25_CRUD_Operations_with_Repository_Pattern.Models;

namespace Day_25_CRUD_Operations_with_Repository_Pattern.Mappers
{
    public static class ProductMapper
    {
        public static ProductResponseDto ToDto(Product product)
        {
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Sku = product.Sku,
                Price = product.Price,
                Stock = product.Stock,
                ReorderLevel = product.ReorderLevel,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt
            };
        }

        public static List<ProductResponseDto> ToDtoList(List<Product> products)
        {
            return products.Select(p => ToDto(p)).ToList();
        }

        public static Product ToProduct(ProductRequestDto product)
        {
            return new Product
            {
                Name = product.Name,
                Sku = product.Sku,
                Price = product.Price,
                Stock = product.Stock,
                ReorderLevel = product.ReorderLevel,
                IsActive = product.IsActive
            };
        }
    }
}