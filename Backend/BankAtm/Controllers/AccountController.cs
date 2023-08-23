using AutoMapper;
using BankAtm.DTOS;
using BankAtm.Entities;
using BankAtm.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using System.Text;

namespace BankAtm.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize(Roles ="admin")]
    public class AccountController : ControllerBase
    {


        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }
        [HttpPost, Route("AddAccount")]
        public IActionResult Add(AccountDTO accountDTO)
        {
            Account account = new Account()
            {
                Id = accountDTO.Id,
                AccType = accountDTO.AccType,
                Balance = accountDTO.Balance,
                CardName = accountDTO.CardName,
                CardNo = accountDTO.CardNo,
                AtmPin= accountDTO.AtmPin,
            };
            account.AccNum = GenerateAccNum(account.AccType, account.Id);
            _accountService.AddAccountDetails(account);
            AccountDetailsDTO accountDetails = _mapper.Map<AccountDetailsDTO>(account);
            return StatusCode(200, accountDetails);
        }

        [HttpGet, Route("GetAccountById")]
        public IActionResult GetAccountById(int id)
        {
            List<Account> li = _accountService.GetAccountByCustId(id);
            List<AccountDetailsDTO> details = _mapper.Map<List<AccountDetailsDTO>>(li);
            return StatusCode(200, details);
        }

        [HttpGet, Route("GetBalanceByAccNo")]
        public IActionResult GetBalanceByaccNo(long accNo)
        {
            Account account = _accountService.GetAccountByAccNo(accNo);
            if (account == null)
            {
                return StatusCode(201, new JsonResult("Account doesn't exists"));
            }
            else return StatusCode(200, account.Balance);
        }

        [HttpGet, Route("GetAccountByAccNo")]
        public IActionResult GetAccountbyAccNo(long AccNo)
        {
            Account account = _accountService.GetAccountByAccNo(AccNo);
            if(account==null) return StatusCode(201, new JsonResult("No account with this Account Number"));
            AccountDetailsDTO accountDetails = _mapper.Map<AccountDetailsDTO>(account);
            return StatusCode(200, accountDetails);
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
                List<AccountDetailsDTO> details = _mapper.Map<List<AccountDetailsDTO>>(accounts);
                return StatusCode(200, details);
            }
            catch (Exception ex) { throw; }
        }

        [HttpPut, Route("UpdateAtmPin")]
        public IActionResult UpdatePin(ChangePinDTO changePinDTO)
        {
            Account account = _accountService.GetAccountByAccNo(changePinDTO.AccNum);
            if(account==null)
            {
                return StatusCode(201, new JsonResult("Invalid Account Number"));
            }
            Account acc = _accountService.GetAccountByCardNum(changePinDTO.CardNo);
            if (acc == null)
            {
                return StatusCode(201, new JsonResult("Invalid Card Number"));
            }
            if(account.AtmPin.Equals(changePinDTO.AtmPin)==false) {
                return StatusCode(201, new JsonResult("wrong pin"));
            }
            account.AtmPin = changePinDTO.NewPin;
            _accountService.UpdatePin(account);
            AccountDetailsDTO accountDetails = _mapper.Map<AccountDetailsDTO>(account);
            return StatusCode(200, accountDetails);
        }

        private static Random RNG = new Random();

        private string Create4DigitString()
        {
            var builder = new StringBuilder();
            while (builder.Length < 4)
            {
                builder.Append(RNG.Next(10).ToString());
            }
            return builder.ToString();
        }

        private long GenerateAccNum(string AccType, int CustomerId) {
            var builder = new StringBuilder();
            builder.Append(Create4DigitString());
            int numAccounts = _accountService.GetAccountByCustId(CustomerId).Count();
            builder.Append(String.Format("{0:00}", numAccounts));
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
