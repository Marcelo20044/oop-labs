namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Organizations;

public class ExchangeRate
{
    public ExchangeRate(int activePlasmaPrise, int gravitationalMatterPrice)
    {
        ActivePlasmaPrise = activePlasmaPrise;
        GravitationalMatterPrice = gravitationalMatterPrice;
    }

    public int ActivePlasmaPrise { get; }
    public int GravitationalMatterPrice { get; }
}