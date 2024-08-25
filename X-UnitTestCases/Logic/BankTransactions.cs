using System.Transactions;
using X_UnitTestCases.Interfaces;
using X_UnitTestCases.Models;

namespace X_UnitTestCases.Logic
{
    public class BankTransactions
    {
        public IVerifyTransactions _transactions { get; set; }
        public BankTransactions(IVerifyTransactions transactions)
        {
            _transactions = transactions;
        }
        public User Deposit(decimal amount, User user)
        {
            var isValid = _transactions.IsValidCustomer(user);
            user.Balance = isValid ? 12345 : 54321;
            var userDetails = _transactions.VerifyTransaction(user);
            return user;
        }
    }
}
