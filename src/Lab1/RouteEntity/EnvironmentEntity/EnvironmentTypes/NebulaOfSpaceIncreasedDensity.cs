using System;
using Itmo.ObjectOrientedProgramming.Lab1.RouteEntity.RouteReporting;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Organizations;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Engine.ImpulseEngineEntity;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteEntity.EnvironmentEntity.EnvironmentTypes;

public class NebulaOfSpaceIncreasedDensity : Environment
{
    private readonly int _antimatterFlaresCount;

    public NebulaOfSpaceIncreasedDensity(int antimatterFlaresCount)
    {
        if (_antimatterFlaresCount < 0)
        {
            throw new ArgumentException("The number of antimatter flares cannot be less than zero");
        }

        _antimatterFlaresCount = antimatterFlaresCount;
    }

    public override RouteReport TryGetThrough(Spaceship? spaceship, ExchangeRate exchangeRate)
    {
        if (spaceship is null)
        {
            throw new ArgumentNullException(nameof(spaceship), "Spaceship can't be null");
        }

        if (exchangeRate is null)
        {
            throw new ArgumentNullException(nameof(exchangeRate), "Exchange rate can't be null");
        }

        // The spaceship must have a jump engine
        if (spaceship.JumpEngine is null)
        {
            return new RouteReport(RouteResult.ShipLoss);
        }

        // Obstacle checking
        Deflector? deflector = spaceship.Deflector;
        if (deflector is null || _antimatterFlaresCount > deflector.AntimatterFlaresCountReflect)
        {
            return new RouteReport(RouteResult.CrewDeath);
        }

        deflector.AntimatterFlaresCountReflect -= _antimatterFlaresCount;

        // Checking the possibility of passing a subspace channel
        if (spaceship.JumpEngine.JumpDistance < (int)Distance)
        {
            return new RouteReport(RouteResult.ShipLoss);
        }

        ImpulseEngine engine = spaceship.ImpulseEngine;
        double travelTime = (double)Distance / engine.SpeedInLightYearsPerHour;
        double spentFuel = engine.ActivePlasmaConsumptionPerStart
                        + (engine.ActivePlasmaConsumptionPerLightYear * travelTime);
        double spentMoney = spentFuel * exchangeRate.GravitationalMatterPrice;

        return new RouteReport(RouteResult.Success, travelTime, spentFuel, spentMoney);
    }
}