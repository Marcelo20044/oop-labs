using Contracts.Accounts;
using Spectre.Console;

namespace Console.Scenarios.Accounts.CheckBalance;

public class CheckBalanceScenario : IScenario
{
    private readonly IAccountService _accountService;

    public CheckBalanceScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Check account balance";

    public void Run()
    {
        long balance = _accountService.CheckBalance();

        AnsiConsole.WriteLine($"balance: {balance}$");
        AnsiConsole.Ask<string>("Ok");
    }
}