namespace Samat.Framework.Queries.Abstractions;

public class CollectionQueryResult<T>
{
    public CollectionQueryResult(IEnumerable<T> items)
    {
        Items = items;
        TotalItems = items.Count();
    }

    public CollectionQueryResult(IEnumerable<T> items, int totalItems)
    {
        Items = items;
        TotalItems = totalItems;
    }

    public int TotalItems { get; set; }
    public IEnumerable<T> Items { get; set; }
}