using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route.EnvironmentEntity;

public class NitrineParticleNebulae : EnvironmentEntity.Environment
{
    private readonly int _spaceWhalesCount;

    public NitrineParticleNebulae(int spaceWhalesCount, PathSectionDistance pathSectionDistance)
    {
        if (_spaceWhalesCount < 0)
        {
            throw new ArgumentException("The number of space whales cannot be less than zero");
        }

        if (pathSectionDistance == PathSectionDistance.None)
        {
            throw new ArgumentException("The distance of path section can't be None");
        }

        _spaceWhalesCount = spaceWhalesCount;
        Distance = pathSectionDistance;
    }

    public override RouteReport TryGetThrough(Spaceship? spaceship)
    {
        if (spaceship is null)
        {
            throw new ArgumentNullException(nameof(spaceship), "Spaceship can't be null");
        }

        // Data for report
        ImpulseEngine engine = spaceship.ImpulseEngine;
        int travelTime = (int)Distance / engine.SpeedInLightYearsPerHour;
        int spentFuel = engine.ActivePlasmaConsumptionPerStart
                        + (engine.ActivePlasmaConsumptionPerLightYear * travelTime);

        // Obstacle checking
        if (spaceship.HasAntiNitrineEmitter)
        {
            return new RouteReport(RouteResult.Success, travelTime, spentFuel);
        }

        Deflector? deflector = spaceship.Deflector;
        if (deflector is null || _spaceWhalesCount > deflector.AntimatterFlaresCountReflect)
        {
            return new RouteReport(RouteResult.ShipDestroyed);
        }

        spaceship.DestroyDeflector();
        return new RouteReport(RouteResult.Success, travelTime, spentFuel);
    }
}