using X_UnitTestCases.Models;

namespace X_UnitTestCases.Interfaces
{
    public interface IVerifyTransactions
    {
        bool IsValidCustomer(User user);
        User VerifyTransaction(User user);
    }
}
