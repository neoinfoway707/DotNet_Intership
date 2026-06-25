using ProductManagement.Application.Common.Dtos;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Mappers
{
    public static class ProductMapper
    {
        public static ProductResponseDto ToDto(Product dto)
        {
            return new ProductResponseDto
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Sku = dto.Sku,
                Price = dto.Price,
                Stock = dto.Stock,
                ImagePath = dto.ImagePath,
                CreatedAt = dto.CreatedAt
            };
        }
        public static List<ProductResponseDto> ToDtoList(List<Product> products)
        {
            return products.Select(p => ToDto(p)).ToList();
        }
    }
}
