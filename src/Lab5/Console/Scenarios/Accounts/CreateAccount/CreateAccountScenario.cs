using Contracts.Accounts;
using Spectre.Console;

namespace Console.Scenarios.Accounts.CreateAccount;

public class CreateAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public CreateAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Create new account";

    public void Run()
    {
        int pin = AnsiConsole.Ask<int>("Enter your pin");
        long accountNumber = _accountService.CreateAccount(pin);

        AnsiConsole.WriteLine($"Created new account: [account number: {accountNumber}] [pin: {pin}]");
        AnsiConsole.Ask<string>("Ok");
    }
}