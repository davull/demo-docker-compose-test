using System.Data;
using Dapper;

namespace Demo_TestContainers.Repositories;

public static partial class Database
{
    public static async Task<bool> DatabaseExists(IDbConnection con, string databaseName)
    {
        var databaseExists = await con.QuerySingleAsync<int>(
            """
            SELECT COUNT(*)
            FROM information_schema.schemata
            WHERE schema_name = @databaseName
            """, new { databaseName });

        return databaseExists == 1;
    }

    public static async Task<bool> TableExists(IDbConnection con, string tableName)
    {
        return await TableExists(con, con.Database, tableName);
    }

    public static async Task<bool> TableExists(IDbConnection con, string databaseName, string tableName)
    {
        var tableExists = await con.QuerySingleAsync<int>(
            """
            SELECT COUNT(*)
            FROM information_schema.tables
            WHERE table_schema = @databaseName
              AND table_name = @tableName
            """, new { databaseName, tableName });

        return tableExists == 1;
    }

    public static async Task CreateDatabase(IDbConnection con, string databaseName, bool use = false)
    {
        await con.ExecuteAsync($"CREATE DATABASE {databaseName}");

        if (use)
        {
            con.ChangeDatabase(databaseName);
        }
    }

    public static async Task DeleteDatabase(IDbConnection con, string databaseName)
    {
        await con.ExecuteAsync($"DROP DATABASE {databaseName}");
    }

    public static async Task DeleteTable(IDbConnection con, string tableName)
    {
        await con.ExecuteAsync($"DROP TABLE {tableName}");
    }
}