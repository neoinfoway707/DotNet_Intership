using MediatR;

namespace ProductManagement.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
