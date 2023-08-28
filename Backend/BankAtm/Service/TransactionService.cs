using BankAtm.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankAtm.Service
{
    public class TransactionService : ITransactionService
    {
        CustomerContext _transactionContext;
        public TransactionService(CustomerContext transactionContext)
        {
            _transactionContext = transactionContext;
        }
        public void AddTransaction(Transaction transaction)
        {
            _transactionContext.Transactions.Add(transaction);
            _transactionContext.SaveChanges();
        }

        public void DeleteTransaction(Guid TransId)
        {
            try
            {
               // _transactionContext.Transactions.Remove(GetTransactionByTransId(TransId));
               // _transactionContext.SaveChanges();
            }catch(ArgumentNullException ex) { throw ex; }
            
        }

        public void DeleteTransaction(string TransId)
        {
            throw new NotImplementedException();
        }
        public List<Transaction> GetTransactionByType(string transtype)
        {
            return (from transaction in _transactionContext.Transactions where transaction.TransType == transtype select transaction).ToList();
        }
        public List<Transaction> GetAllTransactions()
        {
           return _transactionContext.Transactions.ToList();
        }

        public List<Transaction> GetLast10Transactions()
        {
            return _transactionContext.Transactions.Take(10)
                .OrderByDescending(t=>t.TransDateTime).ToList();
        }

        public List<Transaction> GetTransactionByAccNo(long accnum)
        {
            return (from transaction in _transactionContext.Transactions where transaction.AccNum==accnum ||  transaction.ToAccNum == accnum select transaction).ToList();
        }

        public Transaction GetTransactionByTransId(Guid TransId)
        {
            return _transactionContext.Transactions.Find(TransId);
        }

    }
}
