using Contracts.Administrators;
using Spectre.Console;

namespace Console.Scenarios.Administrators.Login;

public class LoginAdministratorScenario : IScenario
{
    private readonly IAdministratorService _administratorService;

    public LoginAdministratorScenario(IAdministratorService administratorService)
    {
        _administratorService = administratorService;
    }

    public string Name => "Login administrator";

    public void Run()
    {
        int id = AnsiConsole.Ask<int>("Enter your username");
        string password = AnsiConsole.Ask<string>("Enter your password");

        AdministratorLoginResult result = _administratorService.Login(id, password);

        string message = result switch
        {
            AdministratorLoginResult.Success => "Successful login",
            AdministratorLoginResult.AdministratorNotFound => "Administrator not found",
            AdministratorLoginResult.InvalidPassword => "Invalid password",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}