using codeislife.crm.data;
using codeislife.crm.data.domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace codeislife.crm.core.services.Customers;
public class CustomerService : ICustomerService
{
    private readonly CrmDbContext _dbContext;

    public CustomerService(CrmDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> DeleteCustomerAsync(Guid id)
    {
        var customer = await _dbContext.FindAsync<Customer>(id);
        if (customer == null) return 0;
        _dbContext.Remove(customer);

        return await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsCustomerAsync(string code)
    {
        return await _dbContext.Set<Customer>()
            .AnyAsync(p => p.Code == code);
    }

    public async Task<IList<Customer>> GetAllCustomersAsync(int pageIndex = 1, int pageSize = 5)
    {
        // 0 * 5 = 0
        // 1 * 5 = 5
        // 2 * 5 = 10
        var query = _dbContext.Customer
            .OrderByDescending(p => p.CreatedDateUtc)
            .Skip((pageIndex * pageSize))
            .Take(pageSize);
        //.Include(c=> c.CustomerContacts)
        //.Include(c=> c.Leads)
        return await query.ToListAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(Guid id)
    {
        return await _dbContext.Set<Customer>().FindAsync(id);
    }

    public async Task<int> GetCustomerCountAsync()
    {
        return await _dbContext.Customer.CountAsync();
    }

    public async Task<Customer> InsertCustomerAsync(Customer customer)
    {
        customer.CreatedDateUtc = DateTime.UtcNow;

        await _dbContext.AddAsync(customer);
        await _dbContext.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> UpdateCustomerAsync(Customer customer)
    {
        _dbContext.Update(customer);
        await _dbContext.SaveChangesAsync();
        return customer;
    }
}
