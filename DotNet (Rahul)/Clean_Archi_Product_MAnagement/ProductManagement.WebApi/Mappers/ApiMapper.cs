using ProductManagement.Application.Features.Products.Command.CreateProduct;
using ProductManagement.Application.Features.Products.Command.UpdateProduct;
using ProductManagement.WebApi.Models;

namespace ProductManagement.WebApi.Mappers
{
    public static class ApiMapper
    {
        public static CreateProductCommand ToCreateCommand(CreateProductRequest command, string Path)
        {
            return new CreateProductCommand
            {
                Name = command.Name,
                Description = command.Description,
                Sku = command.Sku,
                Price = command.Price,
                Stock = command.Stock,
                ImagePath = Path
            };
        }
        public static UpdateProductCommand ToUpdateCommand(UpdateProductRequest command, string Path)
        {
            return new UpdateProductCommand
            {
                Id = command.Id,
                Name = command.Name,
                Description = command.Description,
                Sku = command.Sku,
                Price = command.Price,
                Stock = command.Stock,
                ImagePath = Path
            };
        }
    }
}