using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Products;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            var command = new CreateProductCommand(
                request.Name,
                request.Sku,
                request.Currency,
            request.Amount);

            await _sender.Send(command);

            return Ok(command);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(
            string? searchTerm,
            string? sortColumn,
            string? sortOrder,
            int page,
            int pageSize)
        {
            var query = new GetProductsQuery(searchTerm, sortColumn, sortOrder, page, pageSize);

            var products = await _sender.Send(query);

            return Ok(products);
        }
    }
}
