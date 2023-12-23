using System.Diagnostics.CodeAnalysis;
using Contracts.Accounts;
using Contracts.Administrators;

namespace Console.Scenarios.Accounts.Login;

public class LoginAccountScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _accountService;
    private readonly ICurrentAccountService _currentAccountService;
    private readonly ICurrentAdministratorService _currentAdministratorService;

    public LoginAccountScenarioProvider(
        IAccountService accountService,
        ICurrentAccountService currentAccountService,
        ICurrentAdministratorService currentAdministratorService)
    {
        _accountService = accountService;
        _currentAccountService = currentAccountService;
        _currentAdministratorService = currentAdministratorService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccountService.Account is not null
            || _currentAdministratorService.Administrator is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginAccountScenario(_accountService);
        return true;
    }
}