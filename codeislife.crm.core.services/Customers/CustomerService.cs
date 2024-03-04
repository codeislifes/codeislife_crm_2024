using codeislife.crm.data;
using codeislife.crm.data.domain;
using Microsoft.EntityFrameworkCore;

namespace codeislife.crm.core.services.Customers;
public class CustomerService : ICustomerService
{
    private readonly CrmDbContext _dbContext;

    public CustomerService(CrmDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> DeleteCustomer(Guid id)
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

    public async Task<IList<Customer>> GetAllCustomersAsync(int pageIndex = 0, int pageSize = 10)
    {
        return await _dbContext.Customer.Skip((pageIndex * pageSize)).Take(pageSize).ToListAsync();
    }

    public async Task<int> GetCustomerCountAsync()
    {
        return await _dbContext.Customer.CountAsync();
    }

    public async Task<Customer> InsertCustomer(Customer customer)
    {
        await _dbContext.AddAsync(customer);
        await _dbContext.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> UpdateCustomer(Customer customer)
    {
        _dbContext.Update(customer);
        await _dbContext.SaveChangesAsync();
        return customer;
    }
}
