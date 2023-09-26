using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Organizations;

#pragma warning disable CA5394

public static class FuelExchange
{
    public static ExchangeRate GetExchangeRate()
    {
        var random = new Random();
        return new ExchangeRate(random.Next(60, 71), random.Next(80, 86));
    }
}
#pragma warning restore CA5394