using codeislife.crm.data.domain;

namespace codeislife.crm.core.services.Customers;
public interface ICustomerService
{
    Task<Customer?> GetCustomerByIdAsync(Guid id);
    Task<IList<Customer>> GetAllCustomersAsync(int pageIndex = 0, int pageSize = 10);
    Task<Customer> InsertCustomerAsync(Customer customer);
    Task<Customer> UpdateCustomerAsync(Customer customer);
    Task<int> DeleteCustomerAsync(Guid id);
    Task<bool> ExistsCustomerAsync(string code);
    Task<int> GetCustomerCountAsync();
}
