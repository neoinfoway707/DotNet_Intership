using MediatR;
using ProductManagement.Application.Common.Dtos;

namespace ProductManagement.Application.Features.Products.Query.GetAllProducts
{
    public class GetAllProductsQuery:IRequest<List<ProductResponseDto>>
    {
    }
}
