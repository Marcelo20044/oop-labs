using Application.Accounts;
using Application.Administrators;
using Application.Operations;
using Contracts.Accounts;
using Contracts.Administrators;
using Contracts.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<IAdministratorService, AdministratorService>();
        collection.AddScoped<IOperationService, OperationService>();

        collection.AddScoped<CurrentAccountManager>();
        collection.AddScoped<ICurrentAccountService>(
            p => p.GetRequiredService<CurrentAccountManager>());

        collection.AddScoped<CurrentAdministratorManager>();
        collection.AddScoped<ICurrentAdministratorService>(
            p => p.GetRequiredService<CurrentAdministratorManager>());

        return collection;
    }
}