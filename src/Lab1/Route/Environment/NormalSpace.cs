using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route.Environment;

public class NormalSpace : IEnvironment
{
    private readonly int _asteroidsCount;
    private readonly int _meteoritesCount;

    public NormalSpace(int asteroidsCount, int meteoritesCount)
    {
        if (asteroidsCount < 0)
        {
            throw new ArgumentException("The number of asteroids cannot be less than zero");
        }

        if (meteoritesCount < 0)
        {
            throw new ArgumentException("The number of meteorites cannot be less than zero");
        }

        _asteroidsCount = asteroidsCount;
        _meteoritesCount = meteoritesCount;
    }

    public RouteResult TryGetThrough(Spaceship.Spaceship? spaceship)
    {
        if (spaceship is null)
        {
            throw new ArgumentNullException(nameof(spaceship), "Spaceship can't be null");
        }

        // Obstacle checking
        Deflector? deflector = spaceship.Deflector;
        if (deflector is not null)
        {
            if (_asteroidsCount > deflector.AsteroidsCountReflect || _meteoritesCount > deflector.MeteoritesCountReflect)
            {
                spaceship.DestroyDeflector();
            }
            else
            {
                deflector.AsteroidsCountReflect -= _asteroidsCount;
                deflector.MeteoritesCountReflect -= _meteoritesCount;
            }
        }
        else
        {
            Hull hull = spaceship.Hull;
            if (_asteroidsCount > hull.AsteroidsCountReflect || _meteoritesCount > hull.MeteoritesCountReflect)
            {
                return RouteResult.ShipDestroyed;
            }

            hull.AsteroidsCountReflect -= _asteroidsCount;
            hull.MeteoritesCountReflect -= _meteoritesCount;
        }

        return RouteResult.Success;
    }
}