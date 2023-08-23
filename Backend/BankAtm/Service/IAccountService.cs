using BankAtm.Entities;

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

        int GetBalanceByAccNum(long accNo);
        Account GetAccountByCardNum(string CardNum);
        
    }
}
