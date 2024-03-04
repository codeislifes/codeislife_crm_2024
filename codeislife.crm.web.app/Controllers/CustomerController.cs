using AutoMapper;
using codeislife.crm.core.services.Customers;
using codeislife.crm.data.domain;
using codeislife.crm.web.app.Models;
using Microsoft.AspNetCore.Mvc;

namespace codeislife.crm.web.app.Controllers;
public class CustomerController : Controller
{
    private readonly IMapper _mapper;
    private readonly ICustomerService _customerService;
    public CustomerController
    (
        IMapper mapper,
        ICustomerService customerService
    )
    {
        _mapper = mapper;
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

        var customerModels = customers.Select(p => _mapper.Map<CustomerModel>(p)).ToList();

        var model = new CustomerListModel
        {
            CurrentPage = page,
            PageSize = pageSize,
            Data = customerModels,
            TotalCount = dataCount
        };

        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CustomerCreateModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var customer = _mapper.Map<Customer>(model);
        await _customerService.InsertCustomerAsync(customer);

        if (customer.Id != Guid.Empty)
            return RedirectToAction("Update", new { id = customer.Id });

        return View(model);
    }

    public async Task<IActionResult> Update(Guid id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
            return RedirectToAction("List");

        var model = _mapper.Map<CustomerUpdateModel>(customer);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Update(CustomerUpdateModel model)
    {
        var customer = await _customerService.GetCustomerByIdAsync(model.Id);
        if (customer == null)
            return RedirectToAction("List");

        customer = _mapper.Map(model, customer);
        await _customerService.UpdateCustomerAsync(customer);

        return RedirectToAction("List");
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _customerService.DeleteCustomerAsync(id);
        return RedirectToAction("List");
    }
}
