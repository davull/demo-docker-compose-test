using System.Data;
using MySqlConnector;

namespace Demo_TestContainers.Repositories;

public static class ConnectionProvider
{
    public static async Task<IDbConnection> GetOpenDatabaseConnection(
        string? databaseName = null, uint connectionTimeout = 10)
    {
        databaseName ??= Configuration.DatabaseName;

        var connectionString = new MySqlConnectionStringBuilder
        {
            Server = Configuration.DatabaseServer,
            Port = Configuration.DatabasePort,
            Database = databaseName,
            UserID = Configuration.DatabaseUser,
            Password = Configuration.DatabasePassword,
            ConnectionTimeout = connectionTimeout
        }.ConnectionString;

        var con = new MySqlConnection(connectionString);
        await con.OpenAsync();
        return con;
    }
}