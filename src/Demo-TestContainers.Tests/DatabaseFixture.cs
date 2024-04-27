using System.Data;
using Demo_TestContainers.Repositories;
using Xunit;

namespace Demo_TestContainers.Tests;

public class DatabaseFixture : IAsyncLifetime
{
    public IDbConnection Connection { get; private set; } = null!;

    public async Task InitializeAsync()
    {
        var databaseName = GetRandomTestDatabaseName();
        Connection = await ConnectionProvider.GetOpenDatabaseConnection(connectionTimeout: 3);

        await Database.Seed(Connection, databaseName);

        SetEnvironmentVariables(databaseName);
    }

    public async Task DisposeAsync()
    {
        await Database.DeleteDatabase(Connection, Connection.Database);
    }

    public static string GetRandomTestDatabaseName()
    {
        return $"test_{Guid.NewGuid():N}";
    }

    private static void SetEnvironmentVariables(string databaseName)
    {
        Environment.SetEnvironmentVariable("DB_NAME", databaseName);
    }
}