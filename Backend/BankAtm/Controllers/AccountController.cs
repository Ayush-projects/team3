﻿using AutoMapper;
using BankAtm.CustomExceptions;
using BankAtm.DTOS;
using BankAtm.Entities;
using BankAtm.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if(accountDTO.CardNo.Length!=16)
            {
                return StatusCode(201, new CardNumLength());
            }
            if (accountDTO.AtmPin.Length != 4)
            {
                return StatusCode(201, new PinLength());
            }
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
            try
            {
                _accountService.AddAccountDetails(account);
                AccountDetailsDTO accountDetails = _mapper.Map<AccountDetailsDTO>(account);
                return StatusCode(200, accountDetails);
            }catch(DbUpdateException ex)
            {
                return StatusCode(201, new CustomerExceptions());
            }
            
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
                return StatusCode(201, new InvalidAccNum());
            }
            if(account.AccStatus==0)
            {
                return StatusCode(201, new AccountDisabled());
            }
            else return StatusCode(200, account.Balance);
        }

        [HttpGet, Route("GetAccountByAccNo")]
        public IActionResult GetAccountbyAccNo(long AccNo)
        {
            Account account = _accountService.GetAccountByAccNo(AccNo);
            if (account == null)
            {
                return StatusCode(201, new InvalidAccNum());
            }
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
            catch (Exception ex) { return StatusCode(201, new InvalidAccNum()); }
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
                return StatusCode(201, new InvalidAccNum());
            }
            Account acc = _accountService.GetAccountByCardNum(changePinDTO.CardNo);
            if (acc == null)
            {
                return StatusCode(201, new InvalidCardNum());
            }
            if(account.AccStatus==0)
            {
                return StatusCode(201, new AccountDisabled());
            }
            if(account.AtmPin.Equals(changePinDTO.AtmPin)==false) {
                return StatusCode(201, new InvalidPin());
            }
            if (changePinDTO.NewPin.Length != 4)
            {
                return StatusCode(201, new PinLength());
            }
            if (account.AtmPin.Equals(changePinDTO.NewPin) == true)
            {
                return StatusCode(201, new SamePinException());
            }
            account.AtmPin = changePinDTO.NewPin;
            _accountService.UpdateAccountDetails(account);
            AccountDetailsDTO accountDetails = _mapper.Map<AccountDetailsDTO>(account);
            return StatusCode(200, accountDetails);
        }

        [HttpPut,Route("EnableDisableStatus")]
        public IActionResult AccountStatusUpdate(UserStatus userStatus)
        {
            Account account = _accountService.GetAccountByAccNo(userStatus.AccNum);
            if(account==null)
            {
                return StatusCode(201, new InvalidAccNum());
            }
           

            else
            {
                if(userStatus.AccStatus.Equals("Disable"))
                {
                    if(account.AccStatus==0)
                    {
                        return StatusCode(201, new AlreadyDisabled());
                    }
                    account.AccStatus = 0;
                }
                else
                {

                    if (account.AccStatus == 1)
                    {
                        return StatusCode(201, new AlreadyEnabled());
                    }
                    account.AccStatus= 1;
                }
                _accountService.UpdateAccountDetails(account);
                return StatusCode(200, new JsonResult("Status updated successfully"));
            }
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
