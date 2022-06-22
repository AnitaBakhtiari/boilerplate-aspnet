using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace Util.Paging;

public static class PageExtension
{
    public static async Task<Page<T>> ToPageListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = await source.CountAsync();
        var item = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new Page<T>(item, count, pageNumber, pageSize);
    }

    public static Page<T> ToPageList<T>(this IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var item = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        return new Page<T>(item, count, pageNumber, pageSize);
    }

    public static Page<T> ToPageListWithSort<T>(this IQueryable<T> source, int pageNumber, int pageSize, string orderBy)
    {
        var count = source.Count();
        source.OrderBy("");
        var item = source.OrderBy(orderBy).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        return new Page<T>(item, count, pageNumber, pageSize);
    }
}