using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route.Environment;

public class NitrineParticleNebulae : IEnvironment
{
    private readonly int _spaceWhalesCount;

    public NitrineParticleNebulae(int spaceWhalesCount)
    {
        if (_spaceWhalesCount < 0)
        {
            throw new ArgumentException("The number of space whales cannot be less than zero");
        }

        _spaceWhalesCount = spaceWhalesCount;
    }

    public RouteResult TryGetThrough(Spaceship.Spaceship? spaceship)
    {
        if (spaceship is null)
        {
            throw new ArgumentNullException(nameof(spaceship), "Spaceship can't be null");
        }

        // Obstacle checking
        if (spaceship.HasAntiNitrineEmitter)
        {
            return RouteResult.Success;
        }

        Deflector? deflector = spaceship.Deflector;
        if (deflector is null || _spaceWhalesCount > deflector.AntimatterFlaresCountReflect)
        {
            return RouteResult.ShipDestroyed;
        }

        spaceship.DestroyDeflector();
        return RouteResult.Success;
    }
}