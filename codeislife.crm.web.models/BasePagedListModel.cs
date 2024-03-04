namespace codeislife.crm.web.models;
public class BasePagedListModel<T> : IPagedListModel
{
    public int ShowPageSize { get; set; } = 10;
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public List<T> Data { get; set; }
}
