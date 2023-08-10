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

    public async Task<List<CountryDto>> GetCountriesDataAsync(CountryFilterDto countryFilterDto)
    {
        var httpClient = _httpClientFactory.GetHttpClient();
        var response = await httpClient.GetAsync("v3.1/all");

        var content = await response.Content.ReadAsStringAsync();
        var countries = JsonSerializer.Deserialize<List<CountryDto>>(content);

        if (countries == null || !countries.Any())
        {
            throw new Exception("Service processing api currently unavailable");
        }

        if (!string.IsNullOrWhiteSpace(countryFilterDto.CountryName))
        {
            countries = FilterCountriesByName(countries, countryFilterDto.CountryName);
        }

        return countries;
    }

    private static List<CountryDto> FilterCountriesByName(IEnumerable<CountryDto> countries, string filter)
    {
        var searchQuery = filter.ToLower();

        return countries.Where(country =>
                country.Name.Common.ToLower().Contains(searchQuery) ||
                country.Name.Official.ToLower().Contains(searchQuery))
            .ToList();
    }
}