namespace Contracts.Accounts;

public interface IAccountService
{
    long CreateAccount(int pin);
    AccountLoginResult Login(long accountNumber, int pin);
    UpdateBalanceResult ReplenishAccount(long amount);
    UpdateBalanceResult WithdrawMoney(long amount);
    long CheckBalance();
}