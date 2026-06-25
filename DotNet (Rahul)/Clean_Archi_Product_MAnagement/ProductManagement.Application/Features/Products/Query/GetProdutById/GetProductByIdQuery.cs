using MediatR;
using ProductManagement.Application.Common.Dtos;

namespace ProductManagement.Application.Features.Products.Query.GetProdutById
{
    public class GetProductByIdQuery : IRequest<ProductResponseDto?>
    {
        public int Id { get; set; }
    }
}
