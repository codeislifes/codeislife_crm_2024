using Microsoft.AspNetCore.Mvc;

namespace codeislife.crm.web.app.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return RedirectToRoute("default");
    }
}
