using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Demo_TestContainers.Tests;

public class ConfigurationTests
{
    [Fact]
    public void Should_Have_Configuration()
    {
        using var _ = new AssertionScope();
        Configuration.DatabaseServer.Should().NotBeNullOrWhiteSpace();
        Configuration.DatabasePort.Should().BePositive();
        Configuration.DatabaseName.Should().NotBeNullOrWhiteSpace();
        Configuration.DatabaseUser.Should().NotBeNullOrWhiteSpace();
        Configuration.DatabasePassword.Should().NotBeNullOrWhiteSpace();
    }
}