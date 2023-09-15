using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route.Environment;

public class NebulaOfSpaceIncreasedDensity : IEnvironment
{
    private readonly int _antimatterFlaresCount;
    private readonly SubspaceChannelLength _subspaceChannelLength;

    public NebulaOfSpaceIncreasedDensity(int antimatterFlaresCount, SubspaceChannelLength subspaceChannelLength)
    {
        if (_antimatterFlaresCount < 0)
        {
            throw new ArgumentException("The number of antimatter flares cannot be less than zero");
        }

        if (subspaceChannelLength == SubspaceChannelLength.None)
        {
            throw new ArgumentException("The length of subspace channel can't be None");
        }

        _antimatterFlaresCount = antimatterFlaresCount;
        _subspaceChannelLength = subspaceChannelLength;
    }

    public RouteResult TryGetThrough(Spaceship.Spaceship? spaceship)
    {
        if (spaceship is null)
        {
            throw new ArgumentNullException(nameof(spaceship), "Spaceship can't be null");
        }

        // Obstacle checking
        Deflector? deflector = spaceship.Deflector;
        if (deflector is null || _antimatterFlaresCount > deflector.AntimatterFlaresCountReflect)
        {
            return RouteResult.CrewDeath;
        }

        deflector.AntimatterFlaresCountReflect -= _antimatterFlaresCount;

        // The spaceship must have a jump engine
        if (spaceship.JumpEngine is null)
        {
            return RouteResult.ShipLoss;
        }

        // Checking the possibility of passing a subspace channel
        if (spaceship.JumpEngine.JumpDistance < (int)_subspaceChannelLength)
        {
            return RouteResult.ShipLoss;
        }

        return RouteResult.Success;
    }
}