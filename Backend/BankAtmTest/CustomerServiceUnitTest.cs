using BankAtm.Entities;
using BankAtm.Service;
using Microsoft.EntityFrameworkCore;

namespace BankAtmTest
{
    public class CustomerServiceUnitTest
    {
        private CustomerContext db;
        private ICustomerService customerService;
        private DbContextOptionsBuilder<CustomerContext> dbOptions;
        public CustomerServiceUnitTest() {
            dbOptions = new DbContextOptionsBuilder<CustomerContext>().UseSqlServer("Server=WINDOWS-BVQNF6J;Database=BankDataTest;trusted_Connection=True");
            db = new CustomerContext(dbOptions.Options);
        }

        [Fact]
        public void AddCustomerTest()
        {
            customerService = new CustomerService(db);
            Customer customer = new Customer();
            customer.Name = "TestName1";
            customer.Address = "Mumbai";
            customer.Email = "Test1@gmail.com";
            customer.ContactNo = "9900787890";
            customerService.AddCustomer(customer);
            Customer cust = customerService.GetcustomerByEmail(customer.Email);
            Assert.NotNull(cust);
        }

        [Fact]
        public void GetCustomerByIdTest()
        {
            //Arrange
            customerService = new CustomerService(db);
            Customer customer = customerService.GetCustomerById(1);
            Assert.NotNull(customer);

        }
        [Fact]
        public void GetAllCustomerTest() { 
            customerService = new CustomerService(db);
            List<Customer> listcstm = customerService.GetAllCustomers();
            Assert.Equal(7, listcstm.Count);
        }
      
    }
}