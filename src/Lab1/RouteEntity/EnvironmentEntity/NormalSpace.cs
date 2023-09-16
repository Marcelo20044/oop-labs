using System;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Organizations;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteEntity.EnvironmentEntity;

public class NormalSpace : Environment
{
    private readonly int _asteroidsCount;
    private readonly int _meteoritesCount;

    public NormalSpace(int asteroidsCount, int meteoritesCount, PathSectionDistance pathSectionDistance)
    {
        if (asteroidsCount < 0)
        {
            throw new ArgumentException("The number of asteroids cannot be less than zero");
        }

        if (meteoritesCount < 0)
        {
            throw new ArgumentException("The number of meteorites cannot be less than zero");
        }

        if (pathSectionDistance == PathSectionDistance.None)
        {
            throw new ArgumentException("The distance of path section can't be None");
        }

        _asteroidsCount = asteroidsCount;
        _meteoritesCount = meteoritesCount;
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
                return new RouteReport(RouteResult.ShipDestroyed);
            }

            hull.AsteroidsCountReflect -= _asteroidsCount;
            hull.MeteoritesCountReflect -= _meteoritesCount;
        }

        ImpulseEngine engine = spaceship.ImpulseEngine;
        int travelTime = (int)Distance / engine.SpeedInLightYearsPerHour;
        int spentFuel = engine.ActivePlasmaConsumptionPerStart
                        + (engine.ActivePlasmaConsumptionPerLightYear * travelTime);
        int spentMoney = spentFuel * FuelExchange.ActivePlasmaPrice;

        return new RouteReport(RouteResult.Success, travelTime, spentFuel, spentMoney);
    }
}