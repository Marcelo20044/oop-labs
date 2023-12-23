using Contracts.Operations;
using Models.Operations;
using Spectre.Console;

namespace Console.Scenarios.Operations.ShowOperations;

public class ShowOperationsScenario : IScenario
{
    private readonly IOperationService _operationService;

    public ShowOperationsScenario(IOperationService operationService)
    {
        _operationService = operationService;
    }

    public string Name => "Show account operations";

    public void Run()
    {
        long accountNumber = AnsiConsole.Ask<long>("Enter account number");
        IEnumerable<Operation> operations = _operationService.ShowOperations(accountNumber).ToList();

        if (!operations.Any())
        {
            AnsiConsole.WriteLine($"No operations for account with number: {accountNumber}");
            return;
        }

        foreach (Operation operation in operations)
        {
            switch (operation.BalanceDifference)
            {
                case > 0:
                    AnsiConsole.WriteLine($"+ {operation.BalanceDifference}$");
                    break;
                case < 0:
                    AnsiConsole.WriteLine($"- {operation.BalanceDifference}$");
                    break;
                default:
                    AnsiConsole.WriteLine("Checked balance");
                    break;
            }
        }

        AnsiConsole.Ask<string>("Ok");
    }
}