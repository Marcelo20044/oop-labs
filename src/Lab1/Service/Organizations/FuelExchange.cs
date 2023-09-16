using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Organizations;

public static class FuelExchange
{
#pragma warning disable CA5394
    public static int ActivePlasmaPrice => new Random().Next(60, 71);
    public static int GravitationalMatterPrice => new Random().Next(85, 99);
#pragma warning restore CA5394
}