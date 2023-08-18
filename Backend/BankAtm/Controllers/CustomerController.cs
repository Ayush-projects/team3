﻿using BankAtm.DTOS;
using BankAtm.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace BankAtm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
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
                return StatusCode(200, customer);
                
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
            return StatusCode(200, customer);


            }catch(Exception ex) { throw ex; }
        }

        [HttpGet, Route("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                List<Customer> customers = _customerService.GetAllCustomers();
                return StatusCode(200, customers);


            }
            catch (Exception ex) { return StatusCode(501,ex.Message); }
        }

        [HttpDelete, Route("DeleteCustomerById")]
        public IActionResult DeleteCustById(int id)
        {
            try
            {
                _customerService.DeleteCustomer(id);
                return StatusCode(200, new JsonResult("Deleted"));


            }
            catch (Exception ex) { return StatusCode(201,new JsonResult("Customer Id doesn't exists")); }
        }
        [HttpPut, Route("UpdateCustomerEmail")]
        public IActionResult UpdateCust(CustomerEmail customeremail)
        {
            
            Customer cst = _customerService.GetCustomerById(customeremail.Id);
            if( cst != null )
            {
                try
                {
                    cst.Email = customeremail.Email;
                    _customerService.UpdateCustomer(cst);

                    return StatusCode(200, cst);

                }catch(Exception ex)
                {
                    return StatusCode(201, new JsonResult("Email Id already exists"));
                }


            }
            else
            {
                return StatusCode(202,new JsonResult("Invalid ID"));
            }
           
        }
    }
}
