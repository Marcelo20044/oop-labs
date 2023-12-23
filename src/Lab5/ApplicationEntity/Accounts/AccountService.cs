using Abstractions.Repositories;
using Contracts.Accounts;
using Models.Accounts;

namespace Application.Accounts;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IOperationRepository _operationRepository;
    private readonly CurrentAccountManager _currentAccountManager;

    public AccountService(
        IAccountRepository accountRepository,
        IOperationRepository operationRepository,
        CurrentAccountManager currentAccountManager)
    {
        _accountRepository = accountRepository;
        _operationRepository = operationRepository;
        _currentAccountManager = currentAccountManager;
    }

    public AccountLoginResult Login(long accountNumber, int pin)
    {
        Account? account = _accountRepository.FindAccountByNumber(accountNumber).Result;

        if (account is null) return new AccountLoginResult.AccountNotFound();
        if (account.Pin != pin) return new AccountLoginResult.InvalidPin();

        _currentAccountManager.Account = account;
        return new AccountLoginResult.Success();
    }

    public long CreateAccount(int pin)
    {
        return _accountRepository.CreateAccount(pin).Result;
    }

    public UpdateBalanceResult ReplenishAccount(long amount)
    {
        Account? currentAccount = _currentAccountManager.Account;
        if (currentAccount is null) return new UpdateBalanceResult.NotLoggedIn();

        long newBalance = currentAccount.Balance + amount;
        _accountRepository.UpdateBalance(currentAccount.Number, newBalance);

        _currentAccountManager.Account = currentAccount with { Balance = newBalance };
        _operationRepository.CreateOperation(
            _currentAccountManager.Account.Number,
            amount);

        return new UpdateBalanceResult.Success();
    }

    public UpdateBalanceResult WithdrawMoney(long amount)
    {
        Account? currentAccount = _currentAccountManager.Account;
        if (currentAccount is null) return new UpdateBalanceResult.NotLoggedIn();

        long newBalance = currentAccount.Balance - amount;
        if (newBalance < 0) return new UpdateBalanceResult.NotEnoughMoney();

        _accountRepository.UpdateBalance(currentAccount.Number, newBalance);
        _currentAccountManager.Account = currentAccount with { Balance = newBalance };

        long balanceDifference = amount * -1;
        _operationRepository.CreateOperation(
            _currentAccountManager.Account.Number,
            balanceDifference);

        return new UpdateBalanceResult.Success();
    }

    public long CheckBalance()
    {
        Account? account = _currentAccountManager.Account;
        return account is null ? 0 : _accountRepository.GetBalance(account.Number).Result;
    }
}