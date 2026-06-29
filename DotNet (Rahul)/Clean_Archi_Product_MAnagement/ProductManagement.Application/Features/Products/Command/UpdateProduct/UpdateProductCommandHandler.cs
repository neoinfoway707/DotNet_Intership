using MediatR;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler(IProductRepository repository) : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repo = repository;

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Sku = request.Sku,
                Price = request.Price,
                Stock = request.Stock,
                ImagePath = request.ImagePath
            };

            var update = await _repo.CreateUpdateProduct("update", product, product.Id);
            if (!update)
                return false;
            return true;
        }
    }
}
