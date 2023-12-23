using System.Diagnostics.CodeAnalysis;
using Contracts.Accounts;

namespace Console.Scenarios.Accounts.CheckBalance;

public class CheckBalanceScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _accountService;
    private readonly ICurrentAccountService _currentAccountService;

    public CheckBalanceScenarioProvider(
        IAccountService accountService,
        ICurrentAccountService currentAccountService)
    {
        _accountService = accountService;
        _currentAccountService = currentAccountService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccountService.Account is null)
        {
            scenario = null;
            return false;
        }

        scenario = new CheckBalanceScenario(_accountService);
        return true;
    }
}