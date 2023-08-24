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
    public class TransactionServiceUnitTest
    {
        private CustomerContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<CustomerContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new CustomerContext(options);
            databaseContext.Database.EnsureCreated();
            /*databaseContext.Customers.Add(
                new Customer()
                {
                    Id = 1,
                    Name = "Aditya Jindal",
                    ContactNo = "8529754262",
                    Address = "Sarjapur",
                    Email = "jaditya@gmail.com",
                    Accounts = new List<Account>()
                    {
                        new Account()
                        {
                            Id = 1,
                            AccNum = 9,
                            AccType = "Savings",
                            CardNo = "1000000000000001",
                            CardName = "Aditya Jindal",
                            AtmPin = "4563",
                            AccStatus = 1,
                            Balance = 500,
                            Customer = new Customer()
                            {},
                            Transactions = new List<Transaction>()
                            {}
                        }
                    }
                });*/
            databaseContext.Transactions.Add(
                new Transaction()
                {
                    TransID = new Guid("8d481f66-a1cd-4bcc-84e6-8c3a303b90f8"),
                    TransDateTime = DateTime.Now,
                    TransType = "Withdraw",
                    AccNum = 7868767854321002,
                    ToAccNum = 7868767854321002,
                    Amount = 15,
                    //Account = new Account() { }
                });
            databaseContext.SaveChanges();
            return databaseContext;
        }

        [Fact]
        public void AddTransactionTest()
        {
            //Arrange
            var dbContext = GetDatabaseContext();
            var transactionService = new TransactionService(dbContext);
            var guid = Guid.NewGuid();

            //Act
            Transaction transaction = new Transaction()
            {
                AccNum = 7868767854321001,
                TransID = guid,
                ToAccNum = 7868767854321001,
                Amount = 15,
                TransDateTime = DateTime.Now,
                TransType = "Withdraw",
            };
            transactionService.AddTransaction(transaction);
            Transaction transaction2 = transactionService.GetTransactionByTransId(guid);

            //Assert
            Assert.Equal(transaction2, transaction);
        }

        [Fact]
        public void GetTransactionByTransIdTest()
        {
            //Arrange
            var dbContext = GetDatabaseContext();
            var transactionService = new TransactionService(dbContext);

            //Act
            Transaction transaction = transactionService.GetTransactionByTransId(new Guid("8d481f66-a1cd-4bcc-84e6-8c3a303b90f8"));

            //Assert
            Assert.NotNull(transaction);

        }

        /*[Fact]
        public void UpdateTransactionTest()
        {
            //Arrange
            var dbContext = GetDatabaseContext();
            var transactionService = new TransactionService(dbContext);

            //Act
            transactionService.UpdateTransaction(new Transaction()
            {

            });

            //Assert
            Transaction transaction = transactionService.GetTransactionByTransId(new Guid(""));

        }*/
    }
}