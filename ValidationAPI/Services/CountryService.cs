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

        if (countryFilterDto.CountryPopulation.HasValue)
        {
            countries = FilterByPopulation(countries, countryFilterDto.CountryPopulation.Value);
        }

        if (!string.IsNullOrWhiteSpace(countryFilterDto.SortBy))
        {
            countries = SortCountriesByName(countries, countryFilterDto.SortBy);
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

    private List<CountryDto> FilterByPopulation(IEnumerable<CountryDto> countries, int maxPopulationMillions)
    {
        double maxPopulation = maxPopulationMillions * 1_000_000; // Convert millions to actual population

        return countries.Where(country => country.Population < maxPopulation).ToList();
    }

    private static List<CountryDto> SortCountriesByName(List<CountryDto> countries, string sortOrder)
    {
        if (string.Equals(sortOrder, "ascend", StringComparison.OrdinalIgnoreCase))
        {
            countries = countries.OrderBy(country => country.Name.Common, StringComparer.OrdinalIgnoreCase).ToList();
        }
        else if (string.Equals(sortOrder, "descend", StringComparison.OrdinalIgnoreCase))
        {
            countries = countries.OrderByDescending(country => country.Name.Common, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }
        else
        {
            throw new ArgumentException("Invalid sort order. Use 'ascend' or 'descend'.", nameof(sortOrder));
        }

        return countries;
    }
    
    private List<CountryDto> GetPaginatedList(List<CountryDto> countries, int pagination)
    {
        if (pagination <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pagination), "Limit must be greater than 0");
        }

        return countries.Take(pagination).ToList();
    }
}