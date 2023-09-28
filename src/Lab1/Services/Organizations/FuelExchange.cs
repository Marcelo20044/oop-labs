using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Organizations;

public static class FuelExchange
{
    public static ExchangeRate GetExchangeRate()
    {
        return new ExchangeRate(RandomNumberGenerator.GetInt32(60, 71), RandomNumberGenerator.GetInt32(80, 86));
    }
}
