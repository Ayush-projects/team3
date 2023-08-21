﻿using BankAtm.Entities;

namespace BankAtm.Service
{
    public interface ITransactionService
    {
        void AddTransaction(Transaction transaction);
        List<Transaction> GetAllTransactions();
        List<Transaction> GetLast10Transactions();
        List<Transaction> GetTransactionByType(string transtype);
        List<Transaction> GetTransactionByAccNo(int TransId);
        Transaction GetTransactionByTransId(Guid TransId);
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(string TransId);
    }
}
