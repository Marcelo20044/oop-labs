using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions.Repositories;
using Models.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;

public class AccountRepoMock : IAccountRepository
{
    private readonly IList<Account> _accounts;

    public AccountRepoMock(IList<Account> accounts)
    {
        _accounts = accounts;
    }

    public Task<Account?> FindAccountByNumber(long accountNumber)
    {
        return Task.FromResult(_accounts.ToList().Find(x => x.Number == accountNumber));
    }

    public Task UpdateBalance(long accountNumber, long newBalance)
    {
        Account? account = _accounts.ToList().Find(x => x.Number == accountNumber);
        if (account is null) return Task.CompletedTask;

        Account updatedAccount = account with { Balance = newBalance };
        _accounts.Remove(account);
        _accounts.Add(updatedAccount);

        return Task.CompletedTask;
    }

    public Task<long> GetBalance(long accountNumber)
    {
        Account? account = _accounts.ToList().Find(x => x.Number == accountNumber);

        return account is null ? Task.FromResult(0L) : Task.FromResult(account.Balance);
    }

    public Task<long> CreateAccount(int accountPin)
    {
        long accountNumber = _accounts[^1].Number + 1;
        _accounts.Add(new Account(_accounts[^1].Number + 1, accountPin, 0));

        return Task.FromResult(accountNumber);
    }
}