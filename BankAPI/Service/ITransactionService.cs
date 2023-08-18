using BankAPI.Entities;

namespace BankAPI.Service
{
    public interface ITransactionService
    {
        void AddTransaction(Transaction transaction);
        List<Transaction> GetAllTransactions();
        List<Transaction> GetTransactionByAccNo(int TransId);
        Transaction GetTransactionByTransId(string TransId);
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(int TransId);
    }
}