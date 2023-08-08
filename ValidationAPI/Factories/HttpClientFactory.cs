namespace ValidationAPI.Factories;

public class HttpClientFactory : IHttpClientFactory
{
    private readonly System.Net.Http.IHttpClientFactory _httpClientFactory;
    private readonly string _baseUri;

    public HttpClientFactory(IConfiguration configuration, System.Net.Http.IHttpClientFactory httpClientFactory)
    {
        _baseUri = configuration.GetSection("Country:Uri").Value!;
        _httpClientFactory = httpClientFactory;
    }

    public HttpClient GetHttpClient()
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_baseUri);

        return client;
    }
}