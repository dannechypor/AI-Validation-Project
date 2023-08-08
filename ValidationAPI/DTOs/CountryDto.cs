using System.Text.Json.Serialization;

namespace ValidationAPI.DTOs;

public class CountryDto
{
    [JsonPropertyName("name")]
    public Name Name { get; set; }
    
    [JsonPropertyName("tld")]
    public List<string> Tld { get; set; }
    
    [JsonPropertyName("cca2")]
    public string Cca2 { get; set; }
    
    [JsonPropertyName("ccn3")]
    public string Ccn3 { get; set; }
    
    [JsonPropertyName("cca3")]
    public string Cca3 { get; set; }
    
    [JsonPropertyName("cioc")]
    public string Cioc { get; set; }
    
    [JsonPropertyName("independent")]
    public bool Independent { get; set; }
    
    [JsonPropertyName("status")]
    public string Status { get; set; }
    
    [JsonPropertyName("unMember")]
    public bool UnMember { get; set; }
    
    [JsonPropertyName("currencies")]
    public Currencies Currencies { get; set; }
    
    [JsonPropertyName("idd")]
    public Idd Idd { get; set; }
    
    [JsonPropertyName("capital")]
    public List<string> Capital { get; set; }
    
    [JsonPropertyName("altSpellings")]
    public List<string> AltSpellings { get; set; }
    
    [JsonPropertyName("region")]
    public string Region { get; set; }
    
    [JsonPropertyName("subregion")]
    public string Subregion { get; set; }
    
    [JsonPropertyName("languages")]
    public Languages Languages { get; set; }
    
    [JsonPropertyName("translations")]
    public Translations Translations { get; set; }
    
    [JsonPropertyName("latlng")]
    public List<double> Latlng { get; set; }
    
    [JsonPropertyName("landlocked")]
    public bool Landlocked { get; set; }
    
    [JsonPropertyName("borders")]
    public List<string> Borders { get; set; }
    
    [JsonPropertyName("area")]
    public double Area { get; set; }
    
    [JsonPropertyName("demonyms")]
    public Demonyms Demonyms { get; set; }
    
    [JsonPropertyName("flag")]
    public string Flag { get; set; }
    
    [JsonPropertyName("maps")]
    public Maps Maps { get; set; }
    
    [JsonPropertyName("population")]
    public int Population { get; set; }
    
    [JsonPropertyName("fifa")]
    public string Fifa { get; set; }
    
    [JsonPropertyName("car")]
    public Car Car { get; set; }
    
    [JsonPropertyName("timezones")]
    public List<string> Timezones { get; set; }
    
    [JsonPropertyName("continents")]
    public List<string> Continents { get; set; }
    
    [JsonPropertyName("flags")]
    public Flags Flags { get; set; }
    
    [JsonPropertyName("coatOfArms")]
    public CoatOfArms CoatOfArms { get; set; }
    
    [JsonPropertyName("startOfWeek")]
    public string StartOfWeek { get; set; }
    
    [JsonPropertyName("capitalInfo")]
    public CapitalInfo CapitalInfo { get; set; }
    
    [JsonPropertyName("postalCode")]
    public PostalCode PostalCode { get; set; }
}

public class Name
{
    [JsonPropertyName("common")]
    public string Common { get; set; }
    
    [JsonPropertyName("official")]
    public string Official { get; set; }
    
    [JsonPropertyName("nativeName")]
    public Dictionary<string, NativeName> NativeName { get; set; }
}

public class NativeName
{
    [JsonPropertyName("official")]
    public string Official { get; set; }
    
    [JsonPropertyName("common")]
    public string Common { get; set; }
}

public class Currencies
{
    [JsonPropertyName("sar")]
    public Currency SAR { get; set; }
}

public class Currency
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }
}

public class Idd
{
    [JsonPropertyName("root")]
    public string Root { get; set; }
    
    [JsonPropertyName("suffixes")]
    public List<string> Suffixes { get; set; }
}

public class Languages
{
    [JsonPropertyName("ara")]
    public string Ara { get; set; }
}

public class Translations
{
    [JsonPropertyName("ara")]
    public Translation Ara { get; set; }

    [JsonPropertyName("bre")]
    public Translation Bre { get; set; }

    [JsonPropertyName("ces")]
    public Translation Ces { get; set; }

    [JsonPropertyName("cym")]
    public Translation Cym { get; set; }

    [JsonPropertyName("deu")]
    public Translation Deu { get; set; }

    [JsonPropertyName("est")]
    public Translation Est { get; set; }

    [JsonPropertyName("fin")]
    public Translation Fin { get; set; }

    [JsonPropertyName("fra")]
    public Translation Fra { get; set; }

    [JsonPropertyName("hrv")]
    public Translation Hrv { get; set; }

    [JsonPropertyName("hun")]
    public Translation Hun { get; set; }

    [JsonPropertyName("ita")]
    public Translation Ita { get; set; }

    [JsonPropertyName("jpn")]
    public Translation Jpn { get; set; }

    [JsonPropertyName("kor")]
    public Translation Kor { get; set; }

    [JsonPropertyName("nld")]
    public Translation Nld { get; set; }

    [JsonPropertyName("per")]
    public Translation Per { get; set; }

    [JsonPropertyName("pol")]
    public Translation Pol { get; set; }

    [JsonPropertyName("por")]
    public Translation Por { get; set; }

    [JsonPropertyName("rus")]
    public Translation Rus { get; set; }

    [JsonPropertyName("slk")]
    public Translation Slk { get; set; }

    [JsonPropertyName("spa")]
    public Translation Spa { get; set; }

    [JsonPropertyName("srp")]
    public Translation Srp { get; set; }

    [JsonPropertyName("swe")]
    public Translation Swe { get; set; }

    [JsonPropertyName("tur")]
    public Translation Tur { get; set; }

    [JsonPropertyName("urd")]
    public Translation Urd { get; set; }

    [JsonPropertyName("zho")]
    public Translation Zho { get; set; }
}

public class Translation
{
    [JsonPropertyName("official")]
    public string Official { get; set; }
    
    [JsonPropertyName("common")]
    public string Common { get; set; }
}

public class Demonyms
{
    [JsonPropertyName("eng")]
    public Demonym Eng { get; set; }
    
    [JsonPropertyName("fra")]
    public Demonym Fra { get; set; }
}

public class Demonym
{
    [JsonPropertyName("f")]
    public string F { get; set; }
    
    [JsonPropertyName("m")]
    public string M { get; set; }
}

public class Car
{
    [JsonPropertyName("signs")]
    public List<string> Signs { get; set; }
    
    [JsonPropertyName("side")]
    public string Side { get; set; }
}

public class Flags
{
    [JsonPropertyName("png")]
    public string Png { get; set; }
    
    [JsonPropertyName("svg")]
    public string Svg { get; set; }
    
    [JsonPropertyName("alt")]
    public string Alt { get; set; }
}

public class Maps
{
    [JsonPropertyName("googleMaps")]
    public string GoogleMaps { get; set; }
    
    [JsonPropertyName("openStreetMaps")]
    public string OpenStreetMaps { get; set; }
}

public class PostalCode
{
    [JsonPropertyName("format")]
    public string Format { get; set; }
    
    [JsonPropertyName("regex")]
    public string Regex { get; set; }
}

public class CapitalInfo
{
    [JsonPropertyName("latlng")]
    public List<double> Latlng { get; set; }
}

public class CoatOfArms
{
    [JsonPropertyName("png")]
    public string Png { get; set; }
    
    [JsonPropertyName("svg")]
    public string Svg { get; set; }
}