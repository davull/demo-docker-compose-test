using Demo_TestContainers.Repositories;

namespace Demo_TestContainers.Endpoints;

public static class ProductsEndpoints
{
    public static async Task<IResult> Get()
    {
        using var connection = await ConnectionProvider.GetOpenDatabaseConnection();
        var repository = new ProductsRepository(connection);

        var products = await repository.GetProducts();
        return Results.Ok(products);
    }

    public static async Task<IResult> GetBySku(string sku)
    {
        using var connection = await ConnectionProvider.GetOpenDatabaseConnection();
        var repository = new ProductsRepository(connection);

        var product = await repository.GetProductById(sku);
        return product is not null
            ? Results.Ok(product)
            : Results.NotFound();
    }
}