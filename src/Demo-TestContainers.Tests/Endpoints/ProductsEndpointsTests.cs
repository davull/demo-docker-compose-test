using System.Net;
using Demo_TestContainers.Domain;
using FluentAssertions;
using Xunit;

namespace Demo_TestContainers.Tests.Endpoints;

public class ProductsEndpointsTests : EndpointTestBase
{
    [Fact]
    public async Task Should_Return_All_Products()
    {
        var products = await GetJson<IEnumerable<Product>>("/products");
        products.Should().NotBeNullOrEmpty();
    }

    [Theory]
    [InlineData("MY29339")]
    [InlineData("FA25407")]
    public async Task Should_Return_Product_By_Sku(string sku)
    {
        var product = await GetJson<Product>($"/products/{sku}");
        product.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Return_NotFound_When_Product_Not_Found()
    {
        var response = await Get("/products/INVALID");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}