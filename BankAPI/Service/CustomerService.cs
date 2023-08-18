using BankAPI.Entites;
using BankAPI.Models;

namespace BankAPI.Service
{
    public class CustomerService:ICustomerService
    {
        private readonly BankContext _dbconteact;

        public CustomerService(BankContext dbconteact)
        {
            _dbconteact = dbconteact;
        }

        public void AddCustomer(Customer customer)
        {
            _dbconteact.Customers.Add(customer);
            _dbconteact.SaveChanges();
        }
        public void DeleteCustomer(int id)
        {
            Customer? customer = _dbconteact.Customers.Find(id);
            if(customer != null) _dbconteact.Customers.Remove(customer);
            _dbconteact.SaveChanges();
        }
        public void EditCustomer(Customer customer)
        {
            _dbconteact.Customers.Update(customer);
            _dbconteact.SaveChanges();
        }

        public Customer? GetCustomer(int id)
        {
            Customer? customer = _dbconteact.Customers.Find(id);
            return customer;
        }

        public List<Customer> GetCustomers()
        {
            return _dbconteact.Customers.ToList();
        }
    }
}
