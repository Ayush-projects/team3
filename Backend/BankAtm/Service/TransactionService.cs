﻿using BankAtm.Entities;
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
            Account Toacc = _transactionContext.Accounts.FirstOrDefault(p => p.AccNum == transaction.ToAccNum); 
            if(Toacc == null)
            {
                throw new Exception();
            }
            Account acc = _transactionContext.Accounts.FirstOrDefault(p => p.AccNum == transaction.AccNum);
            if (acc != null)
            {
                if(transaction.TransType.Equals("Withdraw") || transaction.TransType.Equals("withdraw"))
                {
                    if(acc.Balance < transaction.Amount)
                    {
                        throw new Exception("Insufficient Balance");
                    }
                    acc.Balance = acc.Balance - transaction.Amount;
                    Toacc.Balance = Toacc.Balance + transaction.Amount;
                }
                else
                {
                    if (Toacc.Balance < transaction.Amount)
                    {
                        throw new Exception("Insuffiecient Balance");
                    }
                    acc.Balance = acc.Balance + transaction.Amount;
                    Toacc.Balance = Toacc.Balance - transaction.Amount;
                }
                _transactionContext.Accounts.Update(acc);
            }
            // _transactionContext.Accounts.
            try
            {
                _transactionContext.Transactions.Add(transaction);
                _transactionContext.SaveChanges();
            }catch(DbUpdateException ex) { throw ex; }
           
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

        public List<Transaction> GetTransactionByAccNo(int accnum)
        {
            return (from transaction in _transactionContext.Transactions where transaction.AccNum==accnum select transaction).ToList();
        }

        public Transaction GetTransactionByTransId(Guid TransId)
        {
            return _transactionContext.Transactions.Find(TransId);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
