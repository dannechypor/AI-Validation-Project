using NUnit.Framework;
using ValidationAPI.DTOs;
using ValidationAPI.Helpers;

[TestFixture]
public class CountryExtensionsTests
{
    private List<CountryDto> _sampleCountries;

    [SetUp]
    public void Setup()
    {
        _sampleCountries = new List<CountryDto>
        {
            new CountryDto
            {
                Name = new Name
                {
                    Common = "United States",
                    Official = "United States of America"
                },
                Population = 331002651
                // Add more properties as needed
            },
            new CountryDto
            {
                Name = new Name
                {
                    Common = "Canada",
                    Official = "Canada"
                },
                Population = 37742154
                // Add more properties as needed
            },
            // Add more sample countries here
        };
    }
    
    [Test]
    public void FilterByName_WithCommonName_ShouldReturnMatchingCountries()
    {
        // Arrange
        const string filter = "United";
        var countries = _sampleCountries;

        // Act
        var filteredCountries = countries.FilterByName(filter);

        // Assert
        Assert.That(filteredCountries, Is.Not.Null);
        Assert.That(filteredCountries, Has.Count.EqualTo(1));
        Assert.That(filteredCountries.First().Name.Common, Is.EqualTo("United States"));
    }

    [Test]
    public void FilterByName_WithOfficialName_ShouldReturnMatchingCountries()
    {
        // Arrange
        const string filter = "America";
        var countries = _sampleCountries;

        // Act
        var filteredCountries = countries.FilterByName(filter);

        // Assert
        Assert.That(filteredCountries, Is.Not.Null);
        Assert.That(filteredCountries.Count, Is.EqualTo(1));
        Assert.That(filteredCountries.First().Name.Common, Is.EqualTo("United States"));
    }

    [Test]
    public void FilterByName_NoMatches_ShouldReturnEmptyList()
    {
        // Arrange
        const string filter = "Japan";
        var countries = _sampleCountries;

        // Act
        var filteredCountries = countries.FilterByName(filter);

        // Assert
        Assert.That(filteredCountries, Is.Not.Null);
        Assert.That(filteredCountries, Is.Empty);
    }
    
    [Test]
    public void FilterByPopulation_ShouldReturnCountriesWithLessPopulation()
    {
        // Arrange
        const int maxPopulationMillions = 40; // Max population set to 40 million
        var countries = _sampleCountries;

        // Act
        var filteredCountries = countries.FilterByPopulation(maxPopulationMillions);

        // Assert
        Assert.That(filteredCountries, Is.Not.Null);
        Assert.That(filteredCountries, Has.Count.EqualTo(1));
        Assert.That(filteredCountries.First().Name.Common, Is.EqualTo("Canada"));
    }

    [Test]
    public void FilterByPopulation_NoMatches_ShouldReturnEmptyList()
    {
        // Arrange
        const int maxPopulationMillions = 10; // Max population set to 10 million
        var countries = _sampleCountries;

        // Act
        var filteredCountries = countries.FilterByPopulation(maxPopulationMillions);

        // Assert
        Assert.That(filteredCountries, Is.Not.Null);
        Assert.That(filteredCountries, Is.Empty);
    }
    
    [Test]
    public void SortByName_Ascending_ShouldReturnCountriesInAscendingOrder()
    {
        // Arrange
        const string sortOrder = "ascend";
        var countries = _sampleCountries;

        // Act
        var sortedCountries = countries.SortByName(sortOrder);

        // Assert
        Assert.That(sortedCountries, Is.Not.Null);
        Assert.That(sortedCountries.First().Name.Common, Is.EqualTo("Canada"));
    }

    [Test]
    public void SortByName_Descending_ShouldReturnCountriesInDescendingOrder()
    {
        // Arrange
        const string sortOrder = "descend";
        var countries = _sampleCountries;

        // Act
        var sortedCountries = countries.SortByName(sortOrder);

        // Assert
        Assert.That(sortedCountries, Is.Not.Null);
        Assert.That(sortedCountries.First().Name.Common, Is.EqualTo("United States"));
    }

    [Test]
    public void SortByName_InvalidSortOrder_ShouldThrowArgumentException()
    {
        // Arrange
        const string invalidSortOrder = "invalid";
        var countries = _sampleCountries;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => countries.SortByName(invalidSortOrder));
    }
    
    [Test]
    public void Paginate_ShouldReturnFirstNCountries()
    {
        // Arrange
        const int pagination = 1; // Get the first country
        var countries = _sampleCountries;

        // Act
        var paginatedCountries = countries.Paginate(pagination);

        // Assert
        Assert.That(paginatedCountries, Is.Not.Null);
        Assert.That(paginatedCountries, Has.Count.EqualTo(1));
        Assert.That(paginatedCountries.First().Name.Common, Is.EqualTo("United States"));
    }

    [Test]
    public void Paginate_InvalidPagination_ShouldThrowArgumentOutOfRangeException()
    {
        // Arrange
        int invalidPagination = -1; // Negative pagination value
        var countries = _sampleCountries;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => countries.Paginate(invalidPagination));
    }

    [Test]
    public void Paginate_LargerPagination_ShouldReturnAllCountries()
    {
        // Arrange
        const int pagination = 10; // Greater than the number of sample countries
        var countries = _sampleCountries;

        // Act
        var paginatedCountries = countries.Paginate(pagination);

        // Assert
        Assert.That(paginatedCountries, Is.Not.Null);
        Assert.That(paginatedCountries, Has.Count.EqualTo(2)); // Total countries in the sample
    }
}