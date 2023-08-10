using ValidationAPI.DTOs;

namespace ValidationAPI.Interfaces;

public interface ICountryService
{ 
    Task<List<CountryDto>> GetCountriesDataAsync(CountryFilterDto countryFilterDto);
}