
namespace Catalog.API.Products.GetProducts
{
    //public record GetProductsRequest();

    public record GetProdcutsResponse(IEnumerable<Product> products);

    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());

                var response = result.Adapt<GetProdcutsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<GetProdcutsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
        }
    }
}
