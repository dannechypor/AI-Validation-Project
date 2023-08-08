using System.Text.Json;
using ValidationAPI.DTOs;
using ValidationAPI.Interfaces;

namespace ValidationAPI.Services;

public class CountryService : ICountryService
{
    private readonly ValidationAPI.Factories.IHttpClientFactory _httpClientFactory;

    public CountryService(ValidationAPI.Factories.IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<CountryDto>> GetCountriesDataAsync()
    {
        var httpClient = _httpClientFactory.GetHttpClient();
        var response = await httpClient.GetAsync("v3.1/all");

        var content = await response.Content.ReadAsStringAsync();

        var countries = JsonSerializer.Deserialize<List<CountryDto>>(content);
        
        return countries;
    }
}