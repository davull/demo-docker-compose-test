using Dapper;
using Demo_TestContainers.Repositories;
using FluentAssertions;
using Xunit;

namespace Demo_TestContainers.Tests.Repositories;

[Collection(DatabaseCollectionFixture.Name)]
public class DatabaseTests
{
    [Fact]
    public async Task Should_Create_And_Delete_Database()
    {
        var databaseName = DatabaseFixture.GetRandomTestDatabaseName();

        using var con = await ConnectionProvider.GetOpenDatabaseConnection();

        var databaseExists = await Database.DatabaseExists(con, databaseName);
        databaseExists.Should().BeFalse();

        await Database.CreateDatabase(con, databaseName);

        databaseExists = await Database.DatabaseExists(con, databaseName);
        databaseExists.Should().BeTrue();

        await Database.DeleteDatabase(con, databaseName);

        databaseExists = await Database.DatabaseExists(con, databaseName);
        databaseExists.Should().BeFalse();
    }

    [Fact]
    public async Task Should_Create_And_Delete_Table()
    {
        var databaseName = DatabaseFixture.GetRandomTestDatabaseName();
        const string tableName = "Products";

        using var con = await ConnectionProvider.GetOpenDatabaseConnection();
        await Database.CreateDatabase(con, databaseName, true);

        var tableExists = await Database.TableExists(con, databaseName, tableName);
        tableExists.Should().BeFalse();

        await con.ExecuteAsync(
            $"""
             CREATE TABLE {tableName} (
               `Sku` VARCHAR(50) NOT NULL PRIMARY KEY
             )
             """);

        tableExists = await Database.TableExists(con, databaseName, tableName);
        tableExists.Should().BeTrue();

        await Database.DeleteTable(con, tableName);

        tableExists = await Database.TableExists(con, databaseName, tableName);
        tableExists.Should().BeFalse();

        await Database.DeleteDatabase(con, databaseName);
    }

    [Fact]
    public async Task Should_Seed_Database()
    {
        var databaseName = DatabaseFixture.GetRandomTestDatabaseName();

        using var con = await ConnectionProvider.GetOpenDatabaseConnection();

        await Database.Seed(con, databaseName);

        var tableExists = await Database.TableExists(con, databaseName, "Products");
        tableExists.Should().BeTrue();

        await Database.DeleteDatabase(con, databaseName);
    }
}