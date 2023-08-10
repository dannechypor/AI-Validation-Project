using System.Text.Json;
using ValidationAPI.DTOs;
using ValidationAPI.Helpers;
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
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var countries = JsonSerializer.Deserialize<List<CountryDto>>(content);

        if (countries == null || countries.Count == 0)
        {
            throw new Exception(ExceptionMessages.ServiceUnavailable);
        }

        return ApplyFiltersAndSorting(countries, countryFilterDto);
    }

    private static List<CountryDto> ApplyFiltersAndSorting(List<CountryDto> countries, CountryFilterDto filterDto)
    {
        var filteredCountries = countries;

        if (!string.IsNullOrWhiteSpace(filterDto.CountryName))
        {
            filteredCountries = filteredCountries.FilterByName(filterDto.CountryName);
        }

        if (filterDto.CountryPopulation.HasValue)
        {
            filteredCountries = filteredCountries.FilterByPopulation(filterDto.CountryPopulation.Value);
        }

        if (!string.IsNullOrWhiteSpace(filterDto.SortBy))
        {
            filteredCountries = filteredCountries.SortByName(filterDto.SortBy);
        }

        if (filterDto.Pagination.HasValue)
        {
            filteredCountries = filteredCountries.Paginate(filterDto.Pagination.Value);
        }

        return filteredCountries;
    }
}