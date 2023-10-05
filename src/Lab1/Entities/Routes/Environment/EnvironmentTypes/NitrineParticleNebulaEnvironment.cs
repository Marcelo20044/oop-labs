using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Distance;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteReporting;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Organizations;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Environment.EnvironmentTypes;

public class NitrineParticleNebulaEnvironment : BaseEnvironment
{
    public NitrineParticleNebulaEnvironment(Distance distance, int spaceWhalesCount)
        : base(distance.GetDistance())
    {
        if (SpaceWhalesCount < 0)
        {
            throw new ArgumentException("The number of space whales cannot be less than zero");
        }

        SpaceWhalesCount = spaceWhalesCount;
    }

    private int SpaceWhalesCount { get; }

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
        if (spaceship.HasAntiNitrineEmitter)
        {
            report = CalculatingCenter.GetSuccessReport(spaceship.BaseImpulseEngine, Distance, exchangeRate);
            return true;
        }

        if (SpaceWhalesCount == 0)
        {
            report = CalculatingCenter.GetSuccessReport(spaceship.BaseImpulseEngine, Distance, exchangeRate);
            return true;
        }

        if (spaceship is not ISpaceshipWithDeflector spaceshipWithDeflector
            || SpaceWhalesCount > spaceshipWithDeflector.Deflector.SpaceWhalesCountReflect)
        {
            report = new RouteReport(RouteResult.ShipDestroyed);
            return false;
        }

        spaceshipWithDeflector.Deflector.SpaceWhalesCountReflect -= SpaceWhalesCount;
        if (spaceshipWithDeflector.Deflector.SpaceWhalesCountReflect == 0)
        {
            spaceshipWithDeflector.Deflector.Destroy();
        }

        report = CalculatingCenter.GetSuccessReport(spaceship.BaseImpulseEngine, Distance, exchangeRate);
        return true;
    }
}