using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.JumpEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteReporting;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Organizations;

public static class CalculatingCenter
{
    public static RouteReport GetSuccessReport(BaseEngine engine, double distance, ExchangeRate exchangeRate)
    {
        ArgumentNullException.ThrowIfNull(engine);
        ArgumentNullException.ThrowIfNull(exchangeRate);

        double travelTime = distance / engine.Speed;
        double spentFuel = 0;
        double spentMoney = 0;

        switch (engine)
        {
            case BaseImpulseEngine impulseEngine:
                spentFuel = impulseEngine.ActivePlasmaConsumptionPerStart
                            + (impulseEngine.ActivePlasmaConsumptionPerLightYear * travelTime);
                spentMoney = spentFuel * exchangeRate.ActivePlasmaPrise;
                break;
            case BaseJumpEngine jumpEngine:
                spentFuel = jumpEngine.GravitationalMatterConsumptionPerLightYear * travelTime;
                spentMoney = spentFuel * exchangeRate.GravitationalMatterPrice;
                break;
        }

        return new RouteReport(RouteResult.Success, travelTime, spentFuel, spentMoney);
    }
}