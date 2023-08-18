using BankAPI.Entites;
using BankAPI.Models;

namespace BankAPI.Service
{
    public class AccountService : IAccountService
    {
        private readonly BankContext _dbContext;

        public AccountService(BankContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddAccount(Account account)
        {
           _dbContext.Accounts.Add(account);
          _dbContext.SaveChanges();
        }
    }
}
