using Microsoft.EntityFrameworkCore;
using Samat.Framework.Queries.Abstractions;
using System.Linq.Dynamic.Core;

namespace Samat.Framework.Queries.EntityFramework.Extensions;
public static class PagedListExtensions
{
    public async static Task<PagedCollectionQueryResult<TSource>> ToPagedListAsync<TSource, TSortablePropertyCollection>(
        this IQueryable<TSource> source,
        PagedSortableQueryFilter<TSortablePropertyCollection> request,
        CancellationToken cancellationToken = default)
        where TSortablePropertyCollection : ISortablePropertyCollection
    {
        cancellationToken.ThrowIfCancellationRequested();

        var totalItems = await source.CountAsync();

        source = source.OrderBy(request.Ordering);

        var items = await source
            .Skip(request.SkipCount())
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new PagedCollectionQueryResult<TSource>(request.PageNumber, request.PageSize, totalItems, items);
    }
}
