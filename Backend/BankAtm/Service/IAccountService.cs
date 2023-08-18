﻿using BankAtm.Entities;

namespace BankAtm.Service
{
    public interface IAccountService
    {
        void AddAccountDetails(Account account);
        List<Account> GetAllAccounts();
        void UpdateAccountDetails(Account account);
        Account GetAccountByAccNo(long AccNo);
        List<Account> GetAccountByCustId(int id);
        void DeleteAccount(long accNo);

        void UpdateBalance(Account account);
    }
}
