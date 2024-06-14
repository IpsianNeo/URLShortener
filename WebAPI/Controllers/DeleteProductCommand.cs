using MediatR;

namespace WebAPI.Controllers
{
    internal class DeleteProductCommand : IRequest<object>
    {
        public DeleteProductCommand(ProductId productId)
        {
            throw new NotImplementedException();
        }
    }
}