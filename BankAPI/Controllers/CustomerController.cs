using BankAPI.Entites;
using BankAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankAPI.DTOS;
using Microsoft.AspNetCore.Authorization;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpPost,Route("AddCustomer"), Authorize(Roles = "admin")]
        public IActionResult Add(CustomerDTO customerDTO)
        {
            try
            {
                Customer customer = new Customer()
                {
                    Name = customerDTO.Name,
                    Address = customerDTO.Address,
                    City = customerDTO.City,
                    Pincode = customerDTO.Pincode,
                    Email = customerDTO.Email,
                };
                customerService.AddCustomer(customer);
                return StatusCode(200, customerDTO);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet, Route("GetCustomer"), Authorize(Roles = "admin")]
        public IActionResult GetCustomer(int id)
        {
            try
            {
                Customer? customer = customerService.GetCustomer(id);
                return StatusCode(200, customer);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet,Route("GetCustomers"), Authorize(Roles = "admin")]
        public IActionResult GetCustomers()
        {
            return Ok(customerService.GetCustomers());
        }
    }
}
