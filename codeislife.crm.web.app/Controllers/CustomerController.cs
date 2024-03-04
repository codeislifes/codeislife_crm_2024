using codeislife.crm.core.services.Customers;
using codeislife.crm.web.app.Models;
using Microsoft.AspNetCore.Mvc;

namespace codeislife.crm.web.app.Controllers;
public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }


    public async Task<IActionResult> Index()
    {
        //var rnd = new Random();
        //for (int i = 0; i < 5000; i++)
        //{
        //    var code = rnd.Next(1, 7000).ToString();
        //    code = code.PadLeft(10, '0');

        //    var day = rnd.Next(1, 365);
        //    var createdDate = DateTime.UtcNow.AddDays(-day);

        //    var exists = await _customerService.ExistsCustomerAsync(code);
        //    if (exists) continue;

        //    await _customerService.InsertCustomer(new data.domain.Customer
        //    {
        //        Code = code,
        //        Title = Faker.Company.Name(),
        //        CreatedDateUtc = createdDate
        //    });
        //}

        // www.ddd.com/Customer
        return RedirectToAction("List");
    }

    public async Task<IActionResult> List(int page = 1)
    {
        var pageSize = 5;
        var dataCount = await _customerService.GetCustomerCountAsync();

        if (page <= 0)
            page = 1;

        var currentPage = page;

        var customers = await _customerService.GetAllCustomersAsync(pageIndex: --currentPage, pageSize: pageSize);

        var customerModels = customers.Select(p =>
        {
            return new CustomerModel
            {
                Code = p.Code,
                Title = p.Title,
            };
        }).ToList();

        var model = new CustomerListModel
        {
            CurrentPage = page,
            PageSize = pageSize,
            Customers = customerModels,
            TotalCount = dataCount
        };

        return View(model);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(int name)
    {
        return View();
    }




    public IActionResult Update(int id)
    {
        return View();
    }

    [HttpPost]
    public IActionResult Update(string name)
    {
        return View();
    }

    public IActionResult Delete(int id)
    {
        return View();
    }
}
