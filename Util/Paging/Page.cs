namespace Util.Paging;

public class Page<T>
{
    public Page()
    {
    }

    public Page(List<T> content, int totalCount, int pageNumber, int pageSize)
    {
        TotalCount = totalCount;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int) Math.Ceiling(totalCount / (double) pageSize);
        Content = content;
    }

    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public List<T> Content { get; set; }

    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public static Page<T> ToPageList(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var item = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        return new Page<T>(item, count, pageNumber, pageSize);
    }
}