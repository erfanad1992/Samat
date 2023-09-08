namespace Samat.Framework.Queries.Abstractions;

public class PagedCollectionQueryResult<T>
{
    public PagedCollectionQueryResult(int pageNumber, int pageSize, int totalItems, List<T> items)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalItems = totalItems;
        Items = items;
    }
    public int PageNumber { get; }
    public int PageSize { get; }
    public int TotalItems { get; }
    public List<T> Items { get; }
}