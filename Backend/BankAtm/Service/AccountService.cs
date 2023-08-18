using BankAtm.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BankAtm.Service
{
    public class AccountService : IAccountService
    {
        CustomerContext _customerContext;
        public AccountService(CustomerContext dbcustomer)
        {
            _customerContext = dbcustomer;
        }
        public void AddAccountDetails(Account account)
        {
            try
            {
                _customerContext.Accounts.Add(account);
                _customerContext.SaveChanges();
            }
            catch (DbUpdateException ex) { throw ex; }
            
        }

        public Account GetAccountByAccNo(long AccNo)
        {

           Account account = _customerContext.Accounts.FirstOrDefault(p=>p.AccNum == AccNo);
           return account;
        }

        public void DeleteAccount(long accNo)
        {
            try
            {
                Account account = GetAccountByAccNo(accNo);

                _customerContext.Accounts.Remove(account);
                _customerContext.SaveChanges();
            }catch(Exception ex)
            {
                throw ex;
            }

        }

        public List< Account> GetAccountByCustId(int id)
        {
           return  (from  account in _customerContext.Accounts where account.Id == id select account).ToList();
        }

        public List<Account> GetAllAccounts()
        {
           return _customerContext.Accounts.ToList();
        }

        public void UpdateAccountDetails(Account account)
        {
            _customerContext.Accounts.Update(account);
            _customerContext.SaveChanges();
        }

        public void UpdateBalance(Account account)
        {
            
        }
    }
}
