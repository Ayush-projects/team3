using AutoMapper;
using BankAtm.Service;
using BankAtm.Entities;
using Moq;
using BankAtm.Controllers;
using BankAtm.DTOS;

namespace BankAtmTest.Controller
{
    public class TransactionControllerTests
    {
        private readonly Mock<ITransactionService> _transactionService;
        private readonly Mock<IAccountService> _accountService;
        private readonly Mock<IMapper> _mapper;
        public TransactionControllerTests()
        {
            _transactionService = new Mock<ITransactionService>();
            _accountService = new Mock<IAccountService>();
            _mapper = new Mock<IMapper>();
            _mapper.Setup(m => m.Map<Transaction, TransactionDetailsDTO>(It.IsAny<Transaction>()))
                .Returns(new TransactionDetailsDTO());
        }

        [Fact]
        public void TransactionController_AddTransaction_Transfer()
        {
            //Arrange
            Account acc = new Account()
            {
                Id = 1,
                AccNum = 5467290000612301,
                AccStatus = 1,
                AccType = "Savings",
                Balance = 1000,
                AtmPin = "5435",
                CardName = "Aditya Jindal",
                CardNo = "1000000000000001",
            };
            Account acc2 = acc;
            acc2.AccNum = 454672900006121;
            _accountService.Setup(a => a.GetAccountByAccNo(5467290000612301)).Returns(acc);
            _accountService.Setup(a => a.GetAccountByAccNo(454672900006121)).Returns(acc2);
            _accountService.Setup(a => a.UpdateAccountDetails(It.IsAny<Account>())).Verifiable();
            _transactionService.Setup(t => t.AddTransaction(It.IsAny<Transaction>())).Verifiable();
            TransactionDTO transactionDTO = new TransactionDTO()
            {
                AccNum1 = 5467290000612301,
                AccNum2 = 454672900006121,
                Amount = 100,
                TransType = "Transfer"
            };
            //Act
            var controller = new TransactionController(_transactionService.Object, 
                _accountService.Object, _mapper.Object);
            var result = controller.AddNewTransaction(transactionDTO);

            //Assert
            _accountService.Verify(a => a.UpdateAccountDetails(It.IsAny<Account>()), Times.Exactly(2));
            _transactionService.Verify(t => t.AddTransaction(It.IsAny<Transaction>()), Times.Once());
            Assert.NotNull(result);

        }

        [Fact]
        public void TransactionController_AddTransaction_Withdraw()
        {
            //Arrange
            Account acc = new Account()
            {
                Id = 1,
                AccNum = 5467290000612301,
                AccStatus = 1,
                AccType = "Savings",
                Balance = 1000,
                AtmPin = "5435",
                CardName = "Aditya Jindal",
                CardNo = "1000000000000001",
            };
            _accountService.Setup(a => a.GetAccountByAccNo(5467290000612301)).Returns(acc);
            TransactionDTO transactionDTO = new TransactionDTO()
            {
                AccNum1 = 5467290000612301,
                AccNum2 = 5467290000612301,
                Amount = 100,
                TransType = "Withdraw"
            };
            //Act
            var controller = new TransactionController(_transactionService.Object,
                _accountService.Object, _mapper.Object);
            var result = controller.AddNewTransaction(transactionDTO);

            //Assert
            _accountService.Verify(a => a.UpdateAccountDetails(It.IsAny<Account>()), Times.Once());
            _transactionService.Verify(t => t.AddTransaction(It.IsAny<Transaction>()), Times.Once());
            Assert.NotNull(result);

        }
    }
}
