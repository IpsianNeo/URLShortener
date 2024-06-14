using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace Presentation.Products;

public class ProductsModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => "Hello World!");

        app.MapGet("/products", async (ISender sender) =>
        {
            Result<List<ProductResponse>> result = await sender.Send(new GetProductQuery());
            return Results.Ok(result.value);
        });

        app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
        {
            CreateProductCommand command = new request.Adapt<CreateProductCommand>();

            await sender.Send(command);

            return Results.Ok();
        });
    }
}
