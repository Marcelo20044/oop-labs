using System;
using Itmo.ObjectOrientedProgramming.Lab1.RouteEntity.RouteReporting;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Organizations;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Engine.ImpulseEngineEntity;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteEntity.EnvironmentEntity.EnvironmentTypes;

public class NitrineParticleNebula : Environment
{
    private readonly int _spaceWhalesCount;

    public NitrineParticleNebula(int spaceWhalesCount)
    {
        if (_spaceWhalesCount < 0)
        {
            throw new ArgumentException("The number of space whales cannot be less than zero");
        }

        _spaceWhalesCount = spaceWhalesCount;
    }

    public override RouteReport TryGetThrough(Spaceship? spaceship, ExchangeRate exchangeRate)
    {
        if (spaceship is null)
        {
            throw new ArgumentNullException(nameof(spaceship), "Spaceship can't be null");
        }

        if (exchangeRate is null)
        {
            throw new ArgumentNullException(nameof(exchangeRate), "Exchange rate can't be null");
        }

        // Data for report
        ImpulseEngine engine = spaceship.ImpulseEngine;
        double travelTime = (double)Distance / engine.SpeedInLightYearsPerHour;
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