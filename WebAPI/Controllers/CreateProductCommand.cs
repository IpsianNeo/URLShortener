using MediatR;

namespace WebAPI.Controllers
{
    internal class CreateProductCommand : IRequest<object>
    {
        public CreateProductCommand(string? requestName, string? requestSku, string? requestCurrency, int requestAmount)
        {
            throw new NotImplementedException();
        }
    }
}