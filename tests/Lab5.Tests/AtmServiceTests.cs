using System.Collections.Generic;
using Application.Accounts;
using Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;
using Models.Accounts;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

#pragma warning disable CA1707

public class AtmServiceTests
{
    [Fact]
    public void WithdrawMoneyWhenEnough_ShouldSuccess()
    {
        var account = new Account(123, 5252, 0);
        var currentAccountManager = new CurrentAccountManager { Account = account };
        var accounts = new List<Account> { account };

        var accountService = new AccountService(
            new AccountRepoMock(accounts),
            new OperationsRepoMock(),
            currentAccountManager);

        accountService.ReplenishAccount(300);
        UpdateBalanceResult actual = accountService.WithdrawMoney(200);

        Assert.IsType<UpdateBalanceResult.Success>(actual);
    }

    [Fact]
    public void WithdrawMoneyWhenNotEnough_ShouldReturnNotEnoughMoney()
    {
        var account = new Account(123, 5252, 0);
        var currentAccountManager = new CurrentAccountManager { Account = account };
        var accounts = new List<Account> { account };

        var accountService = new AccountService(
            new AccountRepoMock(accounts),
            new OperationsRepoMock(),
            currentAccountManager);

        accountService.ReplenishAccount(300);
        UpdateBalanceResult actual = accountService.WithdrawMoney(400);

        Assert.IsType<UpdateBalanceResult.NotEnoughMoney>(actual);
    }

    [Fact]
    public void AddMoney_BalanceShouldIncrease()
    {
        var account = new Account(123, 5252, 0);
        var currentAccountManager = new CurrentAccountManager { Account = account };
        var accounts = new List<Account> { account };

        var accountService = new AccountService(
            new AccountRepoMock(accounts),
            new OperationsRepoMock(),
            currentAccountManager);

        accountService.ReplenishAccount(300);
        const long expected = 300;
        long actual = accountService.CheckBalance();

        Assert.Equal(expected, actual);
    }
}

#pragma warning restore CA1707