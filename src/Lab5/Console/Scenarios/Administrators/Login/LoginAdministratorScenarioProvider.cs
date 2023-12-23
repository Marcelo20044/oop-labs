using System.Diagnostics.CodeAnalysis;
using Contracts.Accounts;
using Contracts.Administrators;

namespace Console.Scenarios.Administrators.Login;

public class LoginAdministratorScenarioProvider : IScenarioProvider
{
    private readonly IAdministratorService _administratorService;
    private readonly ICurrentAccountService _currentAccountService;
    private readonly ICurrentAdministratorService _currentAdministratorService;

    public LoginAdministratorScenarioProvider(
        IAdministratorService administratorService,
        ICurrentAccountService currentAccountService,
        ICurrentAdministratorService currentAdministratorService)
    {
        _administratorService = administratorService;
        _currentAccountService = currentAccountService;
        _currentAdministratorService = currentAdministratorService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdministratorService.Administrator is not null
            || _currentAccountService.Account is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginAdministratorScenario(_administratorService);
        return true;
    }
}