using GestionExpropaciones.Common;

namespace GestionExpropaciones.Models;

public class PageResponseModel<T>
{
    public List<T> Items { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }

    public PageResponseModel(List<T> items, int totalCount, int page, int pageSize)
    {
        Items = items;
        TotalCount = totalCount;
        Page = page;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling((double)TotalCount / PageSize);
    }

    public PageResponseModel()
    {
        Items = new List<T>();
        TotalCount = 0;
        Page = 1;
        PageSize = Constants.PageSize;
        TotalPages = 1;
    }
}
