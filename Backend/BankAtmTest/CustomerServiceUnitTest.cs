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
            dbOptions = new DbContextOptionsBuilder<CustomerContext>().UseSqlServer("Server=WINDOWS-BVQNF6J;Database=BankData;trusted_Connection=True");
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
            Customer cust = customerService.GetcustomerByEmail("Test1@gmail.com");
            Customer customer = customerService.GetCustomerById(cust.Id);
            Assert.NotNull(customer);

        }
        
        [Fact]
        public void UpdateCustomerTest()
        {
            customerService = new CustomerService(db);
            Customer cust = customerService.GetcustomerByEmail("Test1@gmail.com");
            string newAddress = "Hyderabad";
            cust.Address = newAddress;
            customerService.UpdateCustomer(cust);
            Customer cust2 = customerService.GetcustomerByEmail("Test1@gmail.com");
            Assert.Equal(newAddress,cust2.Address);
        }

        [Fact ]
        public void DelectCustomerTest()
        {
            customerService = new CustomerService(db);
            customerService.DeleteCustomer("Test1@gmail.com");
            Assert.Null(customerService.GetcustomerByEmail("Test1@gmail.com"));
        }

    }
}