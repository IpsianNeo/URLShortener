using MediatR;

namespace WebAPI.Controllers
{
    internal class GetProductQuery : IRequest<object>
    {
        public GetProductQuery(ProductId productId)
        {
            throw new NotImplementedException();
        }
    }
}