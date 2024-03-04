using codeislife.crm.data.domain;

namespace codeislife.crm.core.services.Customers;
public interface ICustomerService
{
    Task<IList<Customer>> GetAllCustomersAsync(int pageIndex = 0, int pageSize = 10);
    Task<Customer> InsertCustomer(Customer customer);
    Task<Customer> UpdateCustomer(Customer customer);
    Task<int> DeleteCustomer(Guid id);
    Task<bool> ExistsCustomerAsync(string code);
    Task<int> GetCustomerCountAsync();
}
