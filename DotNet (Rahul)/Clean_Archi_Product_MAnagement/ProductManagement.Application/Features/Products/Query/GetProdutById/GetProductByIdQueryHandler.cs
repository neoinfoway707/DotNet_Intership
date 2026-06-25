using MediatR;
using ProductManagement.Application.Common.Dtos;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Mappers;

namespace ProductManagement.Application.Features.Products.Query.GetProdutById
{
    public class GetProductByIdQueryHandler(IProductRepository repository) : IRequestHandler<GetProductByIdQuery, ProductResponseDto?>
    {
        private readonly IProductRepository _repo = repository;

        public async Task<ProductResponseDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var getProdcut = await _repo.GetProductById(request.Id);
            if (getProdcut == null)
                return null;
            var toDto = ProductMapper.ToDto(getProdcut);
            return toDto;
        }
    }
}