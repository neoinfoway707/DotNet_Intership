using MediatR;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace ProductManagement.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository repository) : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _repo = repository;

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Sku = request.Sku,
                Price = request.Price,
                Stock = request.Stock,
                ImagePath = request.ImagePath,
                CreatedAt = DateTime.UtcNow
            };
            var add = await _repo.CreateUpdateProduct("insert", product);
            if (!add)
                return 0;
            return product.Id;
        }
    }
}