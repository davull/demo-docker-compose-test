using Demo_TestContainers.Repositories;
using FluentAssertions;
using Snapshooter.Xunit;
using Xunit;

namespace Demo_TestContainers.Tests.Repositories;

[Collection(DatabaseCollectionFixture.Name)]
public class ProductsRepositoryTests(DatabaseFixture fixture)
{
    private readonly ProductsRepository _sut = new(fixture.Connection);

    [Fact]
    public async Task Should_Get_All_Products()
    {
        var products = await _sut.GetProducts();
        products.Should().NotBeEmpty();
    }

    [Theory]
    [InlineData("MY29339")]
    [InlineData("FA25407")]
    public async Task Should_Get_Product_By_Sku(string sku)
    {
        var product = await _sut.GetProductById(sku);
        product.Should().NotBeNull();

        product.Should().MatchSnapshot($"{nameof(Should_Get_Product_By_Sku)}_{sku}");
    }
}