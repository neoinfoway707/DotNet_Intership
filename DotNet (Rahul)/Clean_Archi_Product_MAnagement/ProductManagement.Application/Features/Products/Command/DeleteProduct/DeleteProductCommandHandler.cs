using MediatR;
using ProductManagement.Application.Interfaces.Repositories;

namespace ProductManagement.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler(IProductRepository repository) : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _repo = repository;
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var deleted = await _repo.DeleteProduct(id);
            if (!deleted)
                return false;
            return true;
        }
    }
}
