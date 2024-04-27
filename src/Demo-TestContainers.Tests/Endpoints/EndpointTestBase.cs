using System.Net.Http.Json;
using Xunit;

namespace Demo_TestContainers.Tests.Endpoints;

[Collection(DatabaseCollectionFixture.Name)]
public class EndpointTestBase
{
    private readonly TestWebAppFactory _factory = new();

    private HttpClient Client()
    {
        return _factory.CreateClient();
    }

    public async Task<T?> GetJson<T>(string path)
    {
        using var client = Client();
        return await client.GetFromJsonAsync<T>(path);
    }

    public async Task<HttpResponseMessage> Get(string path)
    {
        using var client = Client();
        return await client.GetAsync(path);
    }
}