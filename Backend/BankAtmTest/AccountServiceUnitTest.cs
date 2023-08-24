using BankAtm.Entities;
using BankAtm.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAtmTest
{
    public class AccountServiceUnitTest
    {
        private CustomerContext db;
        private IAccountService accountService;
        private DbContextOptionsBuilder<CustomerContext> dbOptions;
        public AccountServiceUnitTest()
        {
            dbOptions = new DbContextOptionsBuilder<CustomerContext>().UseSqlServer("Server=WINDOWS-BVQNF6J;Database=BankData;trusted_Connection=True");
            db = new CustomerContext(dbOptions.Options);
        }

        [Fact]
        public void AddAccountDetailsTest()
        {
            accountService = new AccountService(db);
            Account account = new Account();
            account.Id = 3;
            account.AccType = "Savings";
            account.CardName = "Test";
            account.Balance = 100;
            account.CardNo = "4455335566778800";
            account.AtmPin="5566";
            accountService.AddAccountDetails(account);
            Account acc = accountService.GetAccountByCardNum(account.CardNo);
            Assert.NotNull(acc);
        }

        [Fact]
        public void GetAccountByAccNumTest()
        {
            //Arrange
            accountService = new AccountService(db);
            Account account = accountService.GetAccountByAccNo(4532290000000001);
            Assert.NotNull(account);

        }
        

        [Fact]
        public void UpdateCustomerTest()
        {
            accountService = new AccountService(db);
            Account account = accountService.GetAccountByAccNo(4532290000000001);
            string atmpin = "2222";
            account.AtmPin = atmpin;
            accountService.UpdateAccountDetails(account);
            Account acc = accountService.GetAccountByAccNo(4532290000000001);
            Assert.Equal(atmpin,acc.AtmPin);
        }

        [Fact]
        public void GetBalanceByAccNumTest()
        {
            accountService = new AccountService(db);
            Account acc = accountService.GetAccountByAccNo(4532290000000001);
            Assert.Equal(1400, acc.Balance);
        }
    }
}
