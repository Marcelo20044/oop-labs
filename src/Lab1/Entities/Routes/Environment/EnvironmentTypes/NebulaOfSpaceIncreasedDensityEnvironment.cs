using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.JumpEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteReporting;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Organizations;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Environment.EnvironmentTypes;

public class NebulaOfSpaceIncreasedDensityEnvironment : BaseEnvironment
{
    private readonly int _antimatterFlaresCount;

    public NebulaOfSpaceIncreasedDensityEnvironment(int antimatterFlaresCount)
    {
        if (_antimatterFlaresCount < 0)
        {
            throw new ArgumentException("The number of antimatter flares cannot be less than zero");
        }

        _antimatterFlaresCount = antimatterFlaresCount;
    }

    public override RouteReport TryGetThrough(BaseSpaceship? spaceship, ExchangeRate exchangeRate)
    {
        if (spaceship is null)
        {
            throw new ArgumentNullException(nameof(spaceship), "BaseSpaceship can't be null");
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

        BaseJumpEngine engine = spaceship.JumpEngine;
        double travelTime = (double)Distance / engine.Speed;
        double spentFuel = engine.GravitationalMatterConsumptionPerLightYear * travelTime;
        double spentMoney = spentFuel * exchangeRate.GravitationalMatterPrice;

        return new RouteReport(RouteResult.Success, travelTime, spentFuel, spentMoney);
    }
}