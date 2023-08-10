namespace ValidationAPI.Helpers;

public static class ExceptionMessages
{
    public const string ServiceUnavailable = "Service processing API currently unavailable";
    public const string InvalidSortOrder = "Invalid sort order. Use 'ascend' or 'descend'.";
    public const string PaginationOutOfRange = "Pagination limit must be greater than 0";
}