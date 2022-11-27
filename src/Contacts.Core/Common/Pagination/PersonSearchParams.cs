namespace Contacts.Core.Common.Pagination;

public class PersonSearchParams : PaginationParams
{
    public string Query { get; set; }
    public int? GenderId { get; set; }
    public int[] RegionIds { get; set; }
}