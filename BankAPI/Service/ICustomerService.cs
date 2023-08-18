using BankAPI.Entites;

namespace BankAPI.Service
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        Customer? GetCustomer(int id);
        void EditCustomer(Customer customer);
        void DeleteCustomer(int id);
        List<Customer> GetCustomers();
    }
}
