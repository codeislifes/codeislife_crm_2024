using Microsoft.AspNetCore.Mvc;

namespace codeislife.crm.web.app.Controllers;
public class LeadController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("Dashboard");
    }

    public IActionResult Dashboard()
    {
        return View();
    }
}
