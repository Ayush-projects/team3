using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BankAtm.Controllers;
using BankAtm.DTOS;
using BankAtm.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
namespace BankAtmTest
{
    public class CustomerControllerTest
    {

        private CustomerController _customerController;
        private Mock<ICustomerService> mockService;
        Mock<IMapper> mockServicemap;
        public CustomerControllerTest() {
             mockService = new Mock<ICustomerService>();
             mockServicemap = new Mock<IMapper>();
            _customerController = new CustomerController(mockService.Object,mockServicemap.Object);
            
        }

        [Fact]
        void AddCustomerApiTest()
        {
            CustomerDTO cst = new CustomerDTO();
            cst.Email = "TestCnt@gmail.com";
            cst.Address = "nagpur";
            cst.ContactNo = "8899002233";
            cst.Name = "User1";
            var successresult = _customerController.Add(cst);
           var result = Assert.IsType<ObjectResult>(successresult);
            Assert.Equal(200,result.StatusCode);

        }

        [Fact]
        void UpdateCustEmailTest()
        {
            var success = _customerController.GetAllCustomers();
            var result = Assert.IsType<ObjectResult>(success);
            Assert.Equal(200,result.StatusCode);
        }
    }
}
