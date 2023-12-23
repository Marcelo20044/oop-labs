using Contracts.Accounts;
using Spectre.Console;

namespace Console.Scenarios.Accounts.Login;

public class LoginAccountScenario : IScenario
{
    private readonly IAccountService _accountService;

    public LoginAccountScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Login account";

    public void Run()
    {
        long accountNumber = AnsiConsole.Ask<long>("Enter your account number");
        int pin = AnsiConsole.Ask<int>("Enter your pin");

        AccountLoginResult result = _accountService.Login(accountNumber, pin);

        string message = result switch
        {
            AccountLoginResult.Success => "Successful login",
            AccountLoginResult.AccountNotFound => "Account not found",
            AccountLoginResult.InvalidPin => "Invalid pin",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}