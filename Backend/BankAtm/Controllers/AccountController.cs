using BankAtm.DTOS;
using BankAtm.Entities;
using BankAtm.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BankAtm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {


        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost, Route("AddAccount")]
        public IActionResult Add(AccountDTO accountDTO)
        {
            try
            {
                Account account = new Account()
                {
                   Id = accountDTO.Id,
                   AccType = accountDTO.AccType,
                   Balance = accountDTO.Balance,
                   CardName = accountDTO.CardName,
                   CardNo = accountDTO.CardNo,
                   
                };
                account.AccNum = GenerateAccNum(account.AccType, accountDTO.Id);
                _accountService.AddAccountDetails(account);
                return StatusCode(200, account);

            }
            catch (Exception ex) { return StatusCode(201, new JsonResult("Either Customer with such ID doesn't exists or Account Number already exists")); }
        }
        [HttpGet, Route("GetAccountById")]
        public IActionResult GetAccountById(int id)
        {
            try
            {
                List<Account> li = _accountService.GetAccountByCustId(id);
                return StatusCode(200, li);


            }
            catch (Exception ex) { throw; }
        }

        [HttpGet, Route("GetAccountByAccNo")]
        public IActionResult GetAccountbyAccNo(long AccNo)
        {
            try
            {
               Account account = _accountService.GetAccountByAccNo(AccNo);
                return StatusCode(200, account);


            }
            catch (Exception ex) { throw; }
        }

        [HttpDelete, Route("DeleteAccountByAccNo")]
        public IActionResult DeleteAccountByAccNo(long AccNo)
        {
            try
            {
                _accountService.DeleteAccount(AccNo);
                return StatusCode(200, new JsonResult("Deleted"));


            }
            catch (Exception ex) { return StatusCode(201, new JsonResult("No such account number exists")); }
        }

        [HttpGet, Route("GetAllAccounts")]
        public IActionResult GetAllAccounts()
        {
            try
            {
                List<Account> accounts = _accountService.GetAllAccounts();
                return StatusCode(200, accounts);


            }
            catch (Exception ex) { throw; }
        }

        private static Random RNG = new Random();

        private string Create6DigitString()
        {
            var builder = new StringBuilder();
            while (builder.Length < 6)
            {
                builder.Append(RNG.Next(10).ToString());
            }
            return builder.ToString();
        }

        private long GenerateAccNum(string AccType, int CustomerId) {
            var builder = new StringBuilder();
            builder.Append(Create6DigitString());
            string acctypeid = "0000";
            switch(AccType){
                case "Savings":
                    acctypeid = "0101";
                    break;
                case "Recurring Deposit":
                    acctypeid = "5401";
                    break;
                case "Fixed Deposit":
                    acctypeid = "3106";
                    break;
                case "Cheque":
                    acctypeid = "2567";
                    break;
            }
            builder.Append($"{acctypeid}");
            builder.Append(String.Format("{0:000000}", CustomerId));
            return Convert.ToInt64(builder.ToString());
        }
    }
}
