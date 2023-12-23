using Contracts.Accounts;
using Spectre.Console;

namespace Console.Scenarios.Accounts.UpdateBalance.ReplenishAccount;

public class ReplenishAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public ReplenishAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Replenish Account";
    public void Run()
    {
        long amount = AnsiConsole.Ask<long>("How much do you want to replenish your bank account?");

        _accountService.ReplenishAccount(amount);
        AnsiConsole.Ask<string>("Ok");
    }
}