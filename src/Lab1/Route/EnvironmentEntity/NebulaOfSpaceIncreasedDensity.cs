using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route.EnvironmentEntity;

public class NebulaOfSpaceIncreasedDensity : EnvironmentEntity.Environment
{
    private readonly int _antimatterFlaresCount;

    public NebulaOfSpaceIncreasedDensity(int antimatterFlaresCount, PathSectionDistance pathSectionDistance)
    {
        if (_antimatterFlaresCount < 0)
        {
            throw new ArgumentException("The number of antimatter flares cannot be less than zero");
        }

        if (pathSectionDistance == PathSectionDistance.None)
        {
            throw new ArgumentException("The distance of path section can't be None");
        }

        _antimatterFlaresCount = antimatterFlaresCount;
        Distance = pathSectionDistance;
    }

    public override RouteReport TryGetThrough(Spaceship? spaceship)
    {
        if (spaceship is null)
        {
            throw new ArgumentNullException(nameof(spaceship), "Spaceship can't be null");
        }

        // Obstacle checking
        Deflector? deflector = spaceship.Deflector;
        if (deflector is null || _antimatterFlaresCount > deflector.AntimatterFlaresCountReflect)
        {
            return new RouteReport(RouteResult.CrewDeath);
        }

        deflector.AntimatterFlaresCountReflect -= _antimatterFlaresCount;

        // The spaceship must have a jump engine
        if (spaceship.JumpEngine is null)
        {
            return new RouteReport(RouteResult.ShipLoss);
        }

        // Checking the possibility of passing a subspace channel
        if (spaceship.JumpEngine.JumpDistance < (int)Distance)
        {
            return new RouteReport(RouteResult.ShipLoss);
        }

        ImpulseEngine engine = spaceship.ImpulseEngine;
        int travelTime = (int)Distance / engine.SpeedInLightYearsPerHour;
        int spentFuel = engine.ActivePlasmaConsumptionPerStart
                        + (engine.ActivePlasmaConsumptionPerLightYear * travelTime);

        return new RouteReport(RouteResult.Success, travelTime, spentFuel);
    }
}