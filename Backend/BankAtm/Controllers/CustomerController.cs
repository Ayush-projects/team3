using AutoMapper;
using BankAtm.DTOS;
using BankAtm.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                    Name= customerDTO.Name,
                    ContactNo= customerDTO.ContactNo,
                    Address= customerDTO.Address,
                    Email= customerDTO.Email,
                };
                _customerService.AddCustomer(customer);
                CustomerDetailsDTO customerDetails = _mapper.Map<CustomerDetailsDTO>(customer);
                return StatusCode(200, customerDetails);
                
            }catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return StatusCode(201, new JsonResult("Customer Already Exists")); }
        }

        [HttpGet, Route("GetCustomerById")]
        public IActionResult GetCustomer(int id)
        {
            try
            { 
                Customer customer = _customerService.GetCustomerById(id);
                if(customer == null) return StatusCode(201, new JsonResult("No customer with this customer id"));
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
            catch (Exception ex) { return StatusCode(201,new JsonResult("Customer Id doesn't exists")); }
        }
        [HttpPut, Route("UpdateCustomerEmail")]
        public IActionResult UpdateCustEmail(CustomerEmail customeremail)
        {
            
            Customer customer = _customerService.GetCustomerById(customeremail.Id);
            if(customer != null )
            {
                try
                {
                    customer.Email = customeremail.Email;
                   
                    _customerService.UpdateCustomer(customer);

                    CustomerDetailsDTO customerDetails = _mapper.Map<CustomerDetailsDTO>(customer);
                    return StatusCode(200, customerDetails);

                }
                catch(Exception ex)
                {
                    return StatusCode(201, new JsonResult("Email Id already exists"));
                }
            }
            else
            {
                return StatusCode(202,new JsonResult("Invalid ID"));
            }
        }

        [HttpPut, Route("UpdateCustomerAddress")]
        public IActionResult UpdateCustAddress(CustomerAddress customeraddress)
        {

            Customer customer = _customerService.GetCustomerById(customeraddress.Id);
            if (customer != null)
            {
                try
                {
                    customer.Address = customeraddress.Address;

                    _customerService.UpdateCustomer(customer);
                    CustomerDetailsDTO customerDetails = _mapper.Map<CustomerDetailsDTO>(customer);
                    return StatusCode(200, customerDetails);

                }
                catch (Exception ex)
                {
                    return StatusCode(201, new JsonResult("Coudn't update address"));
                }
            }
            else
            {
                return StatusCode(202, new JsonResult("Invalid ID"));
            }
        }

        [HttpPut, Route("UpdateCustomerContactNo")]
        public IActionResult UpdateCustContactNo(CustomerContNo customercontno)
        {

            Customer customer = _customerService.GetCustomerById(customercontno.Id);
            if (customer != null)
            {
                try
                {
                    customer.ContactNo = customercontno.ContactNo;

                    _customerService.UpdateCustomer(customer);

                    CustomerDetailsDTO customerDetails = _mapper.Map<CustomerDetailsDTO>(customer);
                    return StatusCode(200, customerDetails);

                }
                catch (Exception ex)
                {
                    return StatusCode(201, new JsonResult("Couldn't update contact number"));
                }
            }
            else
            {
                return StatusCode(202, new JsonResult("Invalid ID"));
            }

        }

    }
}
