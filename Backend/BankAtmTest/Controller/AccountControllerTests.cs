using AutoMapper;
using BankAtm.Service;
using BankAtm.Entities;
using Moq;
using BankAtm.Controllers;
using BankAtm.DTOS;

namespace BankAtmTest.Controller
{
    public class AccountControllerTests
    {
        private readonly Mock<IAccountService> _accountService;
        private readonly Mock<IMapper> _mapper;
        public AccountControllerTests()
        {
            _accountService = new Mock<IAccountService>();
            _mapper = new Mock<IMapper>();
            _mapper.Setup(m => m.Map<Account, AccountDetailsDTO>(It.IsAny<Account>()))
                .Returns(new AccountDetailsDTO());
        }

        private Account GetDummyAccount(long accNo)
        {
            Account acc = new Account()
            {
                AccNum = accNo,
                Id = 1,
                AccType = "Savings",
                Balance = 1000,
                AtmPin = "4536",
                CardName = "Aditya Jindal",
                CardNo = "1000001000000001",
                AccStatus = 1
            };
            return acc;
        }

        [Fact]
        public void AccountController_AddAccount()
        {
            //Arrange
            AccountDTO acc = new AccountDTO()
            {
                Id = 1,
                AccType = "Savings",
                Balance = 1000,
                AtmPin = "5435",
                CardName = "Aditya Jindal",
                CardNo = "1000001000000001",
            };
            _accountService.Setup(a => a.GetAccountByCustId(1)).Returns(new List<Account>());
            _accountService.Setup(a => a.AddAccountDetails(It.IsAny<Account>())).Verifiable();
            
            //Act
            var controller = new AccountController(_accountService.Object, _mapper.Object);
            var result = controller.Add(acc);

            //Assert
            _accountService.Verify(a => a.GetAccountByCustId(1), Times.Once());
            _accountService.Verify(a => a.AddAccountDetails(It.IsAny<Account>()), Times.Once());
            Assert.NotNull(result);
        }

        [Fact]
        public void AccountController_DeleteAccount() {
            // Arrange
            _accountService.Setup(a => a.DeleteAccount(It.IsAny<long>())).Verifiable();

            // Act
            var controller = new AccountController(_accountService.Object, _mapper.Object);
            var result = controller.DeleteAccountByAccNo(0);
            // Assert
            _accountService.Verify(a => a.DeleteAccount(It.IsAny<long>()), Times.Once());
            Assert.NotNull(result);
        }

        private void SetupAccountUpdate(long accNo, Account acc)
        {
            _accountService.Setup(a => a.GetAccountByAccNo(accNo)).Returns(acc);
            _accountService.Setup(a => a.UpdateAccountDetails(It.IsAny<Account>())).Verifiable();
        }

        private void AssertAccountUpdate(long accNo)
        {
            _accountService.Verify(a => a.GetAccountByAccNo(accNo), Times.Once());
            _accountService.Verify(a => a.UpdateAccountDetails(It.IsAny<Account>()), Times.Once());
        }

        [Fact]
        public void AccountController_StatusUpdate()
        {
            // Arrange
            long accNo = 1004562310923145;
            UserStatus userStatus = new UserStatus()
            {
                AccNum = accNo,
                AccStatus = "Enable"
            };
            Account acc = GetDummyAccount(accNo);
            acc.AccStatus = 0;
            
            SetupAccountUpdate(accNo, acc);

            //Act
            var controller = new AccountController(_accountService.Object, _mapper.Object);
            var result = controller.AccountStatusUpdate(userStatus);

            //Assert
            AssertAccountUpdate(accNo);
            Assert.NotNull(result);
        }

        [Fact]
        public void AccountController_UpdatePin()
        {
            // Arrange
            long accNo = 1004562310923145;
            string cardNo = "1000001000000001";
            ChangePinDTO changePinDTO = new ChangePinDTO()
            {
                AccNum = accNo,
                CardNo = cardNo,
                AtmPin = "4536",
                NewPin = "3456"
            };
            Account acc = GetDummyAccount(accNo);
            SetupAccountUpdate(accNo, acc);
            _accountService.Setup(a => a.GetAccountByCardNum(cardNo)).Returns(acc);

            //Act
            var controller = new AccountController(_accountService.Object, _mapper.Object);
            var result = controller.UpdatePin(changePinDTO);

            //Assert
            AssertAccountUpdate(accNo);
            _accountService.Verify(a => a.GetAccountByCardNum(cardNo), Times.Once());
            Assert.NotNull(result);
        }
    }
}