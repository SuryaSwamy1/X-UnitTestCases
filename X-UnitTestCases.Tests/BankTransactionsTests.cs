using AutoFixture.Xunit2;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X_UnitTestCases.Interfaces;
using X_UnitTestCases.Logic;
using X_UnitTestCases.Models;

namespace X_UnitTestCases.Tests
{
    public class BankTransactionsTests
    {
        [Theory, AutoMoqData]
        public void Deposit(BankTransactions _bankObj,decimal amount, User user, [Frozen] Mock<Interfaces.IVerifyTransactions> moqVerifyTransactoions)
        {
            moqVerifyTransactoions.Setup(x => x.IsValidCustomer(user)).Returns(true);
            moqVerifyTransactoions.Setup(x => x.VerifyTransaction(It.IsAny<User>())).Returns(user);
            var result = _bankObj.Deposit(amount, user);
            Assert.Equal(12345, result.Balance);
            moqVerifyTransactoions.Setup(x => x.IsValidCustomer(user)).Returns(false);
            moqVerifyTransactoions.Setup(x => x.VerifyTransaction(It.IsAny<User>())).Returns(user);
            result = _bankObj.Deposit(amount, user);
            Assert.Equal(54321, result.Balance);
        }
    }
}
