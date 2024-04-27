using System.Data;
using Dapper;
using Demo_TestContainers.Domain;

namespace Demo_TestContainers.Repositories;

public class ProductsRepository(IDbConnection connection)
{
    public Task<IEnumerable<Product>> GetProducts()
    {
        return connection.QueryAsync<Product>("SELECT * FROM Products");
    }

    public Task<Product?> GetProductById(string sku)
    {
        return connection.QuerySingleOrDefaultAsync<Product>(
            "SELECT * FROM Products WHERE Sku = @sku",
            new { sku });
    }
}