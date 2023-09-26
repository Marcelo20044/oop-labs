using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteReporting;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Organizations;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Environment.EnvironmentTypes;

public class NormalSpaceEnvironment : BaseEnvironment
{
    private readonly int _asteroidsCount;
    private readonly int _meteoritesCount;

    public NormalSpaceEnvironment(int asteroidsCount, int meteoritesCount)
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

        // Obstacle checking
        Deflector? deflector = spaceship.Deflector;
        if (deflector is not null)
        {
            if (_asteroidsCount > deflector.AsteroidsCountReflect ||
                _meteoritesCount > deflector.MeteoritesCountReflect)
            {
                spaceship.DestroyDeflector();
            }
            else
            {
                deflector.AsteroidsCountReflect -= _asteroidsCount;
                deflector.MeteoritesCountReflect -= _meteoritesCount;
                if (deflector.AsteroidsCountReflect == 0 && deflector.MeteoritesCountReflect == 0)
                {
                    spaceship.DestroyDeflector();
                }
            }
        }
        else
        {
            Hull hull = spaceship.Hull;
            if (_asteroidsCount > hull.AsteroidsCountReflect
                || _meteoritesCount > hull.MeteoritesCountReflect)
            {
                return new RouteReport(RouteResult.ShipDestroyed);
            }

            hull.AsteroidsCountReflect -= _asteroidsCount;
            hull.MeteoritesCountReflect -= _meteoritesCount;
        }

        BaseImpulseEngine engine = spaceship.BaseImpulseEngine;
        double travelTime = (double)Distance / engine.Speed;
        double spentFuel = engine.ActivePlasmaConsumptionPerStart
                        + (engine.ActivePlasmaConsumptionPerLightYear * travelTime);
        double spentMoney = spentFuel * exchangeRate.ActivePlasmaPrise;

        return new RouteReport(RouteResult.Success, travelTime, spentFuel, spentMoney);
    }
}