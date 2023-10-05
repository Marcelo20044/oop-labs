using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Distance;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteReporting;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Organizations;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Environment.EnvironmentTypes;

public class NormalSpaceEnvironment : BaseEnvironment
{
    public NormalSpaceEnvironment(Distance distance, int asteroidsCount, int meteoritesCount)
        : base(distance.GetDistance())
    {
        if (asteroidsCount < 0)
        {
            throw new ArgumentException("The number of asteroids cannot be less than zero");
        }

        if (meteoritesCount < 0)
        {
            throw new ArgumentException("The number of meteorites cannot be less than zero");
        }

        AsteroidsCount = asteroidsCount;
        MeteoritesCount = meteoritesCount;
    }

    private int AsteroidsCount { get; }
    private int MeteoritesCount { get; }

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

        // Obstacle checking
        if (AsteroidsCount == 0 && MeteoritesCount == 0)
        {
            report = CalculatingCenter.GetSuccessReport(spaceship.BaseImpulseEngine, Distance, exchangeRate);
            return true;
        }

        if (spaceship is not ISpaceshipWithDeflector spaceshipWithDeflector)
        {
            report = new RouteReport(RouteResult.ShipDestroyed);
            return false;
        }

        Deflector deflector = spaceshipWithDeflector.Deflector;
        if (!deflector.IsDestroyed)
        {
            deflector.AsteroidsCountReflect -= AsteroidsCount;
            deflector.MeteoritesCountReflect -= MeteoritesCount;
            if (deflector.AsteroidsCountReflect < 0 || deflector.MeteoritesCountReflect < 0) deflector.Destroy();
        }
        else
        {
            Hull hull = spaceship.Hull;
            if (hull.IsDestroyed)
            {
                report = new RouteReport(RouteResult.ShipDestroyed);
                return false;
            }

            hull.AsteroidsCountReflect -= AsteroidsCount;
            hull.MeteoritesCountReflect -= MeteoritesCount;
            if (hull.AsteroidsCountReflect <= 0 || hull.MeteoritesCountReflect <= 0) hull.Destroy();
        }

        report = CalculatingCenter.GetSuccessReport(spaceship.BaseImpulseEngine, Distance, exchangeRate);
        return true;
    }
}