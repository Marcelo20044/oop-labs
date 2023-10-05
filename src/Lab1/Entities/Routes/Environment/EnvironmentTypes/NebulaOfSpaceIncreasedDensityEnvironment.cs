using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Distance;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteReporting;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Organizations;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Environment.EnvironmentTypes;

public class NebulaOfSpaceIncreasedDensityEnvironment : BaseEnvironment
{
    public NebulaOfSpaceIncreasedDensityEnvironment(Distance distance, int antimatterFlaresCount)
        : base(distance.GetDistance())
    {
        if (AntimatterFlaresCount < 0)
        {
            throw new ArgumentException("The number of antimatter flares cannot be less than zero");
        }

        AntimatterFlaresCount = antimatterFlaresCount;
    }

    private int AntimatterFlaresCount { get; }

    public override bool TryGetThrough(ISpaceship spaceship, ExchangeRate exchangeRate, out RouteReport report)
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
        if (spaceship is not ISpaceshipWithJumpEngine spaceshipWithJumpEngine)
        {
            report = new RouteReport(RouteResult.ShipLoss);
            return false;
        }

        // Checking the possibility of passing a subspace channel
        if (spaceshipWithJumpEngine.JumpEngine.JumpDistance < Distance)
        {
            report = new RouteReport(RouteResult.ShipLoss);
            return false;
        }

        // Obstacle checking
        if (AntimatterFlaresCount == 0)
        {
            report = CalculatingCenter.GetSuccessReport(spaceshipWithJumpEngine.JumpEngine, Distance, exchangeRate);
            return true;
        }

        if (spaceshipWithJumpEngine is not ISpaceshipWithDeflector spaceshipWithDeflector
            || AntimatterFlaresCount > spaceshipWithDeflector.Deflector.AntimatterFlaresCountReflect)
        {
            report = new RouteReport(RouteResult.CrewDeath);
            return false;
        }

        spaceshipWithDeflector.Deflector.AntimatterFlaresCountReflect -= AntimatterFlaresCount;

        report = CalculatingCenter.GetSuccessReport(spaceshipWithJumpEngine.JumpEngine, Distance, exchangeRate);
        return true;
    }
}