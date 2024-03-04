namespace codeislife.crm.web.models;
public interface IPagedListModel
{
   int ShowPageSize { get; set; }
   int CurrentPage { get; set; }
   int PageSize { get; set; }
   int TotalCount { get; set; }
}
