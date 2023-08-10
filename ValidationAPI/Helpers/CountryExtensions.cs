using ValidationAPI.DTOs;
using ValidationAPI.Helpers;

namespace ValidationAPI.Helpers;

public static class CountryExtensions
{
    public static List<CountryDto> FilterByName(this IEnumerable<CountryDto> countries, string filter)
    {
        var searchQuery = filter.ToLower();
        
        return countries.Where(country =>
                country.Name.Common.ToLower().Contains(searchQuery) ||
                country.Name.Official.ToLower().Contains(searchQuery))
            .ToList();
    }

    public static List<CountryDto> FilterByPopulation(this IEnumerable<CountryDto> countries, int maxPopulationMillions)
    {
        double maxPopulation = maxPopulationMillions * 1_000_000;
        
        return countries.Where(country => country.Population < maxPopulation).ToList();
    }

    public static List<CountryDto> SortByName(this IEnumerable<CountryDto> countries, string sortOrder)
    {
        if (string.Equals(sortOrder, "ascend", StringComparison.OrdinalIgnoreCase))
        {
            return countries.OrderBy(country => country.Name.Common, StringComparer.OrdinalIgnoreCase).ToList();
        }
        else if (string.Equals(sortOrder, "descend", StringComparison.OrdinalIgnoreCase))
        {
            return countries.OrderByDescending(country => country.Name.Common, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }
        else
        {
            throw new ArgumentException(ExceptionMessages.InvalidSortOrder, nameof(sortOrder));
        }
    }

    public static List<CountryDto> Paginate(this IEnumerable<CountryDto> countries, int pagination)
    {
        if (pagination <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pagination), ExceptionMessages.PaginationOutOfRange);
        }
        
        return countries.Take(pagination).ToList();
    }
}