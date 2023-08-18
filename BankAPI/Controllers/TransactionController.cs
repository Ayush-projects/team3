/*using BankAPI.DTOS;
using BankAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost, Route("AddTransaction")]
        public IActionResult AddNewTransaction(TransactionDTO transactionDTO)
        {
            try
            {
                Transaction transaction = new Transaction()
                {
                    AccNum = transactionDTO.AccNum,
                    TransID = transactionDTO.TransID,
                    TransType = transactionDTO.TransType,
                    TransDate = transactionDTO.TransDate,
                    TransTime = transactionDTO.TransTime,
                    Amount = transactionDTO.Amount,
                };
                _transactionService.AddTransaction(transaction);
                return StatusCode(200, transactionDTO);
            }
            catch (Exception ex) { throw; }

        }

        [HttpGet, Route("GetAllTransactions")]
        public IActionResult GettAllTransactions()
        {
            try
            {
                List<Transaction> transactions = _transactionService.GetAllTransactions();
                return StatusCode(200, transactions);
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
        public IActionResult GettTransactionByTransId(string TransId)
        {
            try
            {
                Transaction transaction = _transactionService.GetTransactionByTransId(TransId);
                return StatusCode(200, transaction);
            }
            catch (Exception ex) { throw; }

        }
    }
}
*/