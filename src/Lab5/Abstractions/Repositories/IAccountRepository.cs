using Models.Accounts;

namespace Abstractions.Repositories;

public interface IAccountRepository
{
    Task<long> CreateAccount(int accountPin);
    Task<Account?> FindAccountByNumber(long accountNumber);
    Task UpdateBalance(long accountNumber, long newBalance);
    Task<long> GetBalance(long accountNumber);
}