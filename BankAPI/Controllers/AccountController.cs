using BankAPI.Entites;
using BankAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        //Endpoints
        [HttpPost,Route("AddAccount")]
        public IActionResult Add(Account account)
        {
            try
            {
                accountService.AddAccount(account);
                return StatusCode(200, account);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
