using Microsoft.AspNetCore.Mvc;
using ValidationAPI.DTOs;
using ValidationAPI.Filters;
using ValidationAPI.Interfaces;

namespace ValidationAPI.Controllers;

[ApiController]
[Route("[controller]")]
[GlobalExceptionFilter]
public class CountriesController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountriesController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> GetCountries([FromQuery] CountryFilterDto countryFilterDto)
    {
        var countries = await _countryService.GetCountriesDataAsync(countryFilterDto);

        return Ok(countries);
    }
}