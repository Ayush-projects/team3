using BankAtm.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankAtm.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerContext _dbcustomer;
       public CustomerService(CustomerContext dbcustomer)
        {
            _dbcustomer=dbcustomer;
        }
        public void AddCustomer(Customer customer)
        {
            try
            {

                _dbcustomer.Customers.Add(customer);
                _dbcustomer.SaveChanges();
            }catch(DbUpdateException ex)
            {
                throw ex;
            }
            

        }

        public void DeleteCustomer(int id)
        {
            try
            {
                _dbcustomer.Customers.Remove(GetCustomerById(id));
                _dbcustomer.SaveChanges();
            }catch(ArgumentNullException ex) {
                Console.WriteLine(ex.Message);
                throw ex; }
            
            
        }

        public List<Customer> GetAllCustomers()
        {
            return _dbcustomer.Customers.ToList();
        }

        public Customer GetcustomerByEmail(string email)
        {
            return (_dbcustomer.Customers.FirstOrDefault(p => p.Email == email));
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = _dbcustomer.Customers.Find(id);
            return customer;
         }
        
        public void UpdateCustomer(Customer customer)
        {
            //Customer customer = _dbcustomer.Customers.Find(id);
            try
            {

                _dbcustomer.Customers.Update(customer);
                _dbcustomer.SaveChanges();
            }catch(DbUpdateException ex) { throw ex; }



        }
    }
}
