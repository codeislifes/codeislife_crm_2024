using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace codeislife.crm.web.app.Controllers;

[Authorize]
public class HomeController : Controller
{
    // www.sitemiz.com/Home/Index
    public IActionResult Index()
    {
        return View();
    }
}
