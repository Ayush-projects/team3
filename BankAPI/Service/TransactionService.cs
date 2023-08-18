/*using BankAPI.Entites;
using BankAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Service
{
    public class TransactionService : ITransactionService
    {
        DbContext _transactionContext;
        public TransactionService(DbContext transactionContext)
        {
            _transactionContext = transactionContext;
        }
        public void AddTransaction(Transaction transaction)
        {
            Account acc = _transactionContext.Accounts.FirstOrDefault(p => p.AccNum == transaction.AccNum);
            if (acc != null)
            {
                if (transaction.TransType.Equals("Withdraw") || transaction.TransType.Equals("withdraw"))
                {
                    acc.Balance = acc.Balance - transaction.Amount;
                }
                else
                {
                    acc.Balance = acc.Balance + transaction.Amount;
                }
                _transactionContext.Accounts.Update(acc);
            }
            // _transactionContext.Accounts.
            _transactionContext.Transactions.Add(transaction);
            _transactionContext.SaveChanges();
        }

        public void DeleteTransaction(int TransId)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactionContext.Transactions.ToList();
        }

        public List<Transaction> GetTransactionByAccNo(int accnum)
        {
            return (from transaction in _transactionContext.Transactions where transaction.AccNum == accnum select transaction).ToList();
        }

        public Transaction GetTransactionByTransId(string TransId)
        {
            return _transactionContext.Transactions.Find(TransId);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
*/