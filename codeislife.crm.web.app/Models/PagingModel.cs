namespace codeislife.crm.web.app.Models;

public class PagingModel
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int ShowPageSize { get; set; }
}
