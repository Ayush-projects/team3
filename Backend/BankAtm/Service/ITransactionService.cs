using BankAtm.Entities;

namespace BankAtm.Service
{
    public interface ITransactionService
    {
        void AddTransaction(Transaction transaction);
        List<Transaction> GetAllTransactions();
        List<Transaction> GetTransactionByType(string transtype);
        List<Transaction> GetTransactionByAccNo(long accNo);
        Transaction GetTransactionByTransId(Guid TransId);
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(string TransId);
    }
}
