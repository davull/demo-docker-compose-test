using Xunit;

namespace Demo_TestContainers.Tests;

[CollectionDefinition(Name)]
public class DatabaseCollectionFixture : ICollectionFixture<DatabaseFixture>
{
    public const string Name = "DatabaseCollection";
}