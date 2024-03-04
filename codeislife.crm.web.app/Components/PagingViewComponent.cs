using codeislife.crm.web.app.Models;
using Microsoft.AspNetCore.Mvc;

namespace codeislife.crm.web.app.Components;

[ViewComponent(Name = "paging")]
public class PagingViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(CustomerListModel pagingModel)
    {
        var model = new PagingModel
        {
            PageIndex = pagingModel.CurrentPage,
            PageSize = pagingModel.PageSize,
            ShowPageSize = pagingModel.ShowPageSize,
            TotalCount = pagingModel.TotalCount
        };

        return await Task.FromResult(View(model));
    }
}
