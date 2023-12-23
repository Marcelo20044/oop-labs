namespace Contracts.Accounts;

public abstract record UpdateBalanceResult
{
    private UpdateBalanceResult() { }

    public sealed record Success : UpdateBalanceResult;

    public sealed record NotEnoughMoney : UpdateBalanceResult;

    public sealed record NotLoggedIn : UpdateBalanceResult;
}