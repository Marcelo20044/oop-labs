using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteReporting;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Organizations;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Environment.EnvironmentTypes;

public class NitrineParticleNebulaEnvironment : BaseEnvironment
{
    private readonly int _spaceWhalesCount;

    public NitrineParticleNebulaEnvironment(int spaceWhalesCount)
    {
        if (_spaceWhalesCount < 0)
        {
            throw new ArgumentException("The number of space whales cannot be less than zero");
        }

        _spaceWhalesCount = spaceWhalesCount;
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

        // Data for report
        BaseImpulseEngine engine = spaceship.BaseImpulseEngine;
        double travelTime = (double)Distance / engine.Speed;
        double spentFuel = engine.ActivePlasmaConsumptionPerStart
                        + (engine.ActivePlasmaConsumptionPerLightYear * travelTime);
        double spentMoney = spentFuel * exchangeRate.ActivePlasmaPrise;

        // Obstacle checking
        if (spaceship.HasAntiNitrineEmitter)
        {
            return new RouteReport(RouteResult.Success, travelTime, spentFuel, spentMoney);
        }

        Deflector? deflector = spaceship.Deflector;
        if (deflector is null || _spaceWhalesCount > deflector.SpaceWhalesCountReflect)
        {
            return new RouteReport(RouteResult.ShipDestroyed);
        }

        spaceship.DestroyDeflector();
        return new RouteReport(RouteResult.Success, travelTime, spentFuel, spentMoney);
    }
}