using AutoMapper;
using BankAtm.CustomExceptions;
using BankAtm.DTOS;
using BankAtm.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankAtm.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize(Roles = "admin")]
    //[ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpPost,Route("AddCustomer")]
        public IActionResult Add(CustomerDTO customerDTO)
        {
            try
            {

                Customer customer = new Customer()
                {
                    // Id= customerDTO.Id,
                    Name = customerDTO.Name,
                    ContactNo = customerDTO.ContactNo,
                    Address = customerDTO.Address,
                    Email = customerDTO.Email,
                };
                _customerService.AddCustomer(customer);
                CustomerDetailsDTO customerDetails = _mapper.Map<CustomerDetailsDTO>(customer);
                return StatusCode(200, customerDetails);

            }
            catch (Exception ex)
            {
                return StatusCode(201, new EmailIdException());
            }
        }

        [HttpGet, Route("GetCustomerById")]
        public IActionResult GetCustomer(int id)
        {
            try
            { 
                Customer customer = _customerService.GetCustomerById(id);
                if(customer == null) return StatusCode(201, new CustomerExceptions());
                CustomerDetailsDTO customerDetails = _mapper.Map<CustomerDetailsDTO>(customer);
                return StatusCode(200, customerDetails);
            }
            catch(Exception ex) { throw ex; }
        }

        [HttpGet, Route("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                List<Customer> customers = _customerService.GetAllCustomers();
                List<CustomerDetailsDTO> details = _mapper.Map<List<CustomerDetailsDTO>>(customers);
                return StatusCode(200, details);
            }
            catch (Exception ex) { return StatusCode(501,ex.Message); }
        }

        [HttpDelete, Route("DeleteCustomerById")]
        public IActionResult DeleteCustByEmail(string email)
        {
            try
            {
                _customerService.DeleteCustomer(email);
                return StatusCode(200, new JsonResult("Deleted"));
            }
            catch (Exception ex) { return StatusCode(201,new CustomerExceptions()); }
        }

        [HttpPut, Route("UpdateCustomer")]
        public IActionResult UpdateCustomer(UpdateCustomer updt)
        {

            Customer customer = _customerService.GetCustomerById(updt.Id);
            if (customer != null)
            {
                try
                {
                    customer.ContactNo = updt.ContactNo;
                    customer.Address = updt.Address;
                    customer.Email = updt.Email;

                    _customerService.UpdateCustomer(customer);

                    CustomerDetailsDTO customerDetails = _mapper.Map<CustomerDetailsDTO>(customer);
                    return StatusCode(200, customerDetails);

                }
                catch (Exception ex)
                {
                    return StatusCode(201, new JsonResult("Couldn't update customer details"));
                }
            }
            else
            {
                return StatusCode(201, new CustomerExceptions());
            }

        }

    }
}
