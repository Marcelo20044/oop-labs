using Console.Scenarios.Accounts.CheckBalance;
using Console.Scenarios.Accounts.CreateAccount;
using Console.Scenarios.Accounts.Login;
using Console.Scenarios.Accounts.UpdateBalance.ReplenishAccount;
using Console.Scenarios.Accounts.UpdateBalance.WithdrawMoney;
using Console.Scenarios.Administrators.Login;
using Console.Scenarios.Operations.ShowOperations;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        // Account scenario providers
        collection.AddScoped<IScenarioProvider, CheckBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ReplenishAccountScenarioProvider>();

        // Administrator scenario providers
        collection.AddScoped<IScenarioProvider, LoginAdministratorScenarioProvider>();

        // Operations scenario providers
        collection.AddScoped<IScenarioProvider, ShowOperationsScenarioProvider>();

        return collection;
    }
}