namespace codeislife.crm.web.app.Models;

public class CustomerListModel
{
    public int ShowPageSize { get; set; } = 10;
    public int TotalCount { get; set; }
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; }
    public List<CustomerModel> Customers { get; set; }
}
