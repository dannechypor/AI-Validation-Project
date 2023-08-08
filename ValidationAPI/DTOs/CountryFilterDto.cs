namespace ValidationAPI.DTOs;

public class CountryFilterDto
{
    public string? CountryName { get; set; }
    public int? CountryPopulation { get; set; }
    public string? SortBy { get; set; }
    public int? Pagination { get; set; }
}