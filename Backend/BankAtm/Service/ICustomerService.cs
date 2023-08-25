using BankAtm.Entities;
namespace BankAtm.Service

{ }
public interface ICustomerService
{
    void AddCustomer(Customer customer);
    List<Customer> GetAllCustomers();
    Customer GetCustomerById(int id);
    void UpdateCustomer(Customer customer);
    void DeleteCustomer(string email);
    Customer GetcustomerByEmail(string email);
}
