using BankAtm.DTOS;
using BankAtm.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankAtm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BankAtm.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize(Roles = "admin")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost,Route("AddTransaction")]
        public IActionResult AddNewTransaction(TransactionDTO transactionDTO)
        {
            
            try
            {
                Transaction transaction = new Transaction()
                {
                    AccNum = transactionDTO.AccNum1,

                    TransType = transactionDTO.TransType,
                    TransDateTime = DateTime.Now,
                    ToAccNum=transactionDTO.AccNum2,
                    Amount= transactionDTO.Amount,
                };
                _transactionService.AddTransaction(transaction);
                return StatusCode(200, transactionDTO);
            }catch (DbUpdateException ex) { return StatusCode(201, new JsonResult("No such Account number exists ")); }
            catch(Exception ex) {return StatusCode(201, new JsonResult(ex.Message)); }
        }

        [HttpGet, Route("GetAllTransactions")]
        public IActionResult GettAllTransactions()
        {
            try
            {
                List<Transaction> transactions = _transactionService.GetAllTransactions();
                return StatusCode(200, transactions);
            }catch(Exception ex) { throw; }
            
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
                    return StatusCode(200, transactions);
                }
                return StatusCode(201, new JsonResult("Enter 'deposite' or 'withdraw'"));

            }
            catch (Exception ex) { throw; }

        }
        [HttpGet, Route("GetTransactionsByAccNum")]
        public IActionResult GettTransactionsByAccNum(int AccNum)
        {
            try
            {
                List<Transaction> transactions = _transactionService.GetTransactionByAccNo(AccNum);
                return StatusCode(200, transactions);
            }
            catch (Exception ex) { throw; }

        }

        [HttpGet, Route("GetTransactionByTransId")]
        public IActionResult GettTransactionByTransId(Guid TransId)
        {
            try
            {
                Transaction transaction = _transactionService.GetTransactionByTransId(TransId);
                
                if(transaction == null)
                {
                    return StatusCode(201, new JsonResult("Invalid Transaction ID"));
                }
                return StatusCode(200, transaction);
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
