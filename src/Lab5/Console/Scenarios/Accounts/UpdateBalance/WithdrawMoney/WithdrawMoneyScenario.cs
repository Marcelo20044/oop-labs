using Contracts.Accounts;
using Spectre.Console;

namespace Console.Scenarios.Accounts.UpdateBalance.WithdrawMoney;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IAccountService _accountService;

    public WithdrawMoneyScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Withdraw money from account";

    public void Run()
    {
        long amount = AnsiConsole.Ask<long>("How much do you want to withdraw from your account");

        _accountService.WithdrawMoney(amount);
        AnsiConsole.Ask<string>("Ok");
    }
}