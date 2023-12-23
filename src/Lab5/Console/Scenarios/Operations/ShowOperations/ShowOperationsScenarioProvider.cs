using System.Diagnostics.CodeAnalysis;
using Contracts.Accounts;
using Contracts.Operations;

namespace Console.Scenarios.Operations.ShowOperations;

public class ShowOperationsScenarioProvider : IScenarioProvider
{
    private readonly IOperationService _operationService;
    private readonly ICurrentAccountService _currentAccountService;

    public ShowOperationsScenarioProvider(IOperationService operationService, ICurrentAccountService currentAccountService)
    {
        _operationService = operationService;
        _currentAccountService = currentAccountService;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentAccountService.Account is null)
        {
            scenario = null;
            return false;
        }

        scenario = new ShowOperationsScenario(_operationService);
        return true;
    }
}