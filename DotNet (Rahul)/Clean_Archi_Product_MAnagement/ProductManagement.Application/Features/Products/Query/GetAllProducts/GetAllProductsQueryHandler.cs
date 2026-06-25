using MediatR;
using ProductManagement.Application.Common.Dtos;
using ProductManagement.Application.Interfaces.Repositories;
using ProductManagement.Application.Mappers;

namespace ProductManagement.Application.Features.Products.Query.GetAllProducts
{
    public class GetAllProductsQueryHandler(IProductRepository repository) : IRequestHandler<GetAllProductsQuery, List<ProductResponseDto>>
    {
        private readonly IProductRepository _repo = repository;
        public async Task<List<ProductResponseDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var listOfProducts = await _repo.GetAllProducts();
            var toList = ProductMapper.ToDtoList(listOfProducts);
            return toList;
        }
    }
}
