using MediatR;

namespace WebAPI.Controllers
{
    internal class UpdateProductCommand : IRequest<object>
    {
        public UpdateProductCommand(ProductId productId, string requestName, string requestSku, string requestCurrency, int requestAmount)
        {
            throw new NotImplementedException();
        }
    }
}