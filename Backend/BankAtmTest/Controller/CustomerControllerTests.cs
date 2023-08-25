using AutoMapper;
using BankAtm.DTOS;
using BankAtm.Service;
using BankAtm.Entities;
using Moq;
using BankAtm.Controllers;

namespace BankAtmTest.Controller
{
    public class CustomerControllerTests
    {
        private readonly Mock<ICustomerService> _customerService;
        private readonly Mock<IMapper> _mapper;
        public CustomerControllerTests()
        {
            _customerService = new Mock<ICustomerService>();
            _mapper = new Mock<IMapper>();
            _mapper.Setup(m => m.Map<Customer, CustomerDetailsDTO>(It.IsAny<Customer>()))
                .Returns(new CustomerDetailsDTO());
        }

        private Customer GetDummyCustomer()
        {
            Customer customer = new Customer()
            {
                Name = "Aditya Jindal",
                Address = "Sarjapur",
                ContactNo = "8529753621",
                Email = "jaditya@gmail.com",
                Id = 1,
            };
            return customer;
        }

        [Fact]
        public void CustomerController_AddCustomer()
        {
            //Arrange
            var customerDTO = new Mock<CustomerDTO>();
            _customerService.Setup(a => a.AddCustomer(It.IsAny<Customer>())).Verifiable();

            //Act
            var controller = new CustomerController(_customerService.Object, _mapper.Object);
            var result = controller.Add(customerDTO.Object);

            //Assert
            _customerService.Verify(a => a.AddCustomer(It.IsAny<Customer>()), Times.Once());
            Assert.NotNull(result);
        }

        private Customer SetupUpdateCustomer()
        {
            Customer customer = GetDummyCustomer();
            _customerService.Setup(a => a.GetCustomerById(0)).Returns(customer);
            _customerService.Setup(a => a.UpdateCustomer(It.IsAny<Customer>())).Verifiable();
            return customer;
        }

        private void AssertUpdateCustomer()
        {
            _customerService.Verify(a => a.GetCustomerById(0), Times.Once());
            _customerService.Verify(a => a.UpdateCustomer(It.IsAny<Customer>()), Times.Once());
        }

        [Fact]
        public void CustomerController_UpdateCustomer_Email()
        {
            //Arrange
            Customer customer = SetupUpdateCustomer();
            var customerEmail = new Mock<CustomerEmail>();

            //Act
            var controller = new CustomerController(_customerService.Object, _mapper.Object);
            var result = controller.UpdateCustEmail(customerEmail.Object);

            //Assert
            AssertUpdateCustomer();
            Assert.NotNull(result);
        }

        [Fact]
        public void CustomerController_UpdateCustomer_Contact()
        {
            //Arrange
            Customer customer = SetupUpdateCustomer();
            var customerContact = new Mock<CustomerContNo>();

            //Act
            var controller = new CustomerController(_customerService.Object, _mapper.Object);
            var result = controller.UpdateCustContactNo(customerContact.Object);

            //Assert
            AssertUpdateCustomer();
            Assert.NotNull(result);
        }

        [Fact]
        public void CustomerController_UpdateCustomer_Address()
        {
            //Arrange
            Customer customer = SetupUpdateCustomer();
            var customerAddress = new Mock<CustomerAddress>();

            //Act
            var controller = new CustomerController(_customerService.Object, _mapper.Object);
            var result = controller.UpdateCustAddress(customerAddress.Object);

            //Assert
            AssertUpdateCustomer();
            Assert.NotNull(result);
        }

        [Fact]
        public void CustomerController_GetCustomer()
        {
            //Arrange
            Customer customer = GetDummyCustomer();
            _customerService.Setup(c => c.GetCustomerById(1)).Returns(customer);

            //Act
            var controller = new CustomerController(_customerService.Object, _mapper.Object);
            var result = controller.GetCustomer(1);

            //Assert
            _customerService.Verify(c => c.GetCustomerById(1), Times.Once());
            Assert.NotNull(result);
        }
    }
}
