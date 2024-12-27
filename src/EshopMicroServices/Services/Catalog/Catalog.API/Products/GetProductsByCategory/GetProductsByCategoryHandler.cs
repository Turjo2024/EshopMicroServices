
namespace Catalog.API.Products.GetProductsByCategory
{
    public record GetProductByCategoryQuery(string category) : IQuery<GetProductByCategoryResult>;

    public record GetProductByCategoryResult(IEnumerable<Product> Products);

    internal class GetProductsByCategoryHandler
        (IDocumentSession session, ILogger<GetProductsByCategoryHandler> logger)
        : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsByCategoryHandler.Handle called with {query}", query);

            var products = await session.Query<Product>()
                .Where(p => p.Category.Contains(query.category))
                .ToListAsync();

            return new GetProductByCategoryResult(products);
        }
    }
}
