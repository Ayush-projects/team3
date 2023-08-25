using BankAtm.DTOS;
using BankAtm.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankAtm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace BankAtm.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize(Roles = "admin")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        
        public TransactionController(ITransactionService transactionService, IAccountService accountService,
            IMapper mapper)
        {
            _transactionService = transactionService;
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpGet, Route("GetLast10Transactions")]
        public IActionResult GetLast10Transactions()
        {
            try
            {
                List<Transaction> transactions = _transactionService.GetLast10Transactions();
                List<TransactionDetailsDTO> details = _mapper.Map<List<TransactionDetailsDTO>>(transactions);
                return StatusCode(200, details);
            }
            catch (Exception ex) { throw; }
        }

        [HttpPost,Route("AddTransaction")]
        public IActionResult AddNewTransaction(TransactionDTO transactionDTO)
        {
            try
            {
                Account acc = _accountService.GetAccountByAccNo(transactionDTO.AccNum1);
                if (acc == null)
                {
                    throw new Exception("Account2 doesnt't exists");
                }
                if (acc.AccStatus == 0)
                {
                    throw new Exception("Account is disabled");
                }
                if (acc.Balance < transactionDTO.Amount)
                {
                    throw new Exception("Insufficient Balance");
                }
                if (transactionDTO.TransType.Equals("withdraw", StringComparison.CurrentCultureIgnoreCase))
                {
                    acc.Balance = acc.Balance - transactionDTO.Amount;
                    _accountService.UpdateAccountDetails(acc);
                }
                else
                {
                    Account Toacc = _accountService.GetAccountByAccNo(transactionDTO.AccNum2);
                    if (Toacc == null)
                    {
                        throw new Exception("Account2 doesnt't exists");
                    }
                    if (Toacc.AccStatus == 0)
                    {
                        throw new Exception("Account is disabled");
                    }
                    if (transactionDTO.TransType.Equals("Transfer", StringComparison.CurrentCultureIgnoreCase))
                    {
                        acc.Balance = acc.Balance - transactionDTO.Amount;
                        Toacc.Balance = Toacc.Balance + transactionDTO.Amount;
                    }
                    _accountService.UpdateAccountDetails(acc);
                    _accountService.UpdateAccountDetails(Toacc);
                }
                Transaction transaction = new Transaction()
                {
                    AccNum = transactionDTO.AccNum1,
                    TransType = transactionDTO.TransType,
                    TransDateTime = DateTime.Now,
                    ToAccNum = transactionDTO.AccNum2,
                    Amount = transactionDTO.Amount,
                };
                _transactionService.AddTransaction(transaction);
                TransactionDetailsDTO transactionDetails = _mapper.Map<TransactionDetailsDTO>(transaction);
                return StatusCode(200, transactionDetails);
            }catch(Exception ex) {return StatusCode(201, new JsonResult(ex.Message)); }
        }

        [HttpGet, Route("GetAllTransactions")]
        public IActionResult GettAllTransactions()
        {
            try
            {
                List<Transaction> transactions = _transactionService.GetAllTransactions();
                List<TransactionDetailsDTO> details = _mapper.Map<List<TransactionDetailsDTO>>(transactions);
                return StatusCode(200, details);
            }
            catch(Exception ex) { throw; }
            
        }
        [HttpGet, Route("GetTransactionsByType")]
        public IActionResult GetTransactionsByType(string transtype)
        {
            transtype = transtype.ToLower();
            try
            {

                if (transtype.Equals("deposite") == true || transtype.Equals("withdraw") == true)
                {
                    List<Transaction> transactions = _transactionService.GetTransactionByType(transtype);
                    List<TransactionDetailsDTO> details = _mapper.Map<List<TransactionDetailsDTO>>(transactions);
                    return StatusCode(200, details);
                }
                return StatusCode(201, new JsonResult("Enter 'deposite' or 'withdraw'"));

            }
            catch (Exception ex) { throw; }

        }
        [HttpGet, Route("GetTransactionsByAccNum")]
        public IActionResult GetTransactionsByAccNum(long AccNum)
        {
            try
            {
                List<Transaction> transactions = _transactionService.GetTransactionByAccNo(AccNum);
                List<TransactionDetailsDTO> details = _mapper.Map<List<TransactionDetailsDTO>>(transactions);
                return StatusCode(200, details);
            }
            catch (Exception ex) { throw; }

        }

        [HttpGet, Route("GetTransactionByTransId")]
        public IActionResult GettTransactionByTransId(Guid TransId)
        {
            try
            {
                Transaction transaction = _transactionService.GetTransactionByTransId(TransId);
                
                if(transaction == null) return StatusCode(201, new JsonResult("Invalid Transaction ID"));
                TransactionDetailsDTO transactionDetails = _mapper.Map<TransactionDetailsDTO>(transaction);
                return StatusCode(200, transactionDetails);
            }
            catch (Exception ex) { throw; }

        }

        [HttpDelete, Route("DeleteTransByTransID")]
        public IActionResult DeleteTransByTransId(string TransId)
        {
            try
            {
                _transactionService.DeleteTransaction(TransId);
                return StatusCode(200, new JsonResult("Deleted"));


            }
            catch (Exception ex) { return StatusCode(201, new JsonResult("Invalid Transaction ID")); }
        }
    }
}
