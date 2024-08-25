using X_UnitTestCases.Interfaces;
using X_UnitTestCases.Models;

namespace X_UnitTestCases.Logic
{
    public class VerifyTransactions : Interfaces.IVerifyTransactions
    {
        public bool IsValidCustomer(User user)
        {
            return true;
        }

        public User VerifyTransaction(User user)
        {
            return user;
        }
    }
}
