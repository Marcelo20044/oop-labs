using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine.ImpulseEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipModels;

public class PleasureShuttleSpaceship : ISpaceship
{
    public PleasureShuttleSpaceship(BaseImpulseEngine impulseEngine, Hull hull, bool hasAntiNitrineEmitter = false)
    {
        if (impulseEngine is not ImpulseEngineC)
        {
            throw new ArgumentException("Pleasure Shuttle can only have a class C impulse engine");
        }

        if (hull is null || hull.StrengthClass != StrengthClasses.Class1)
        {
            throw new ArgumentException("Pleasure Shuttle can only have a first strength class hull");
        }

        BaseImpulseEngine = impulseEngine;
        Hull = hull;
        HasAntiNitrineEmitter = hasAntiNitrineEmitter;
    }

    public BaseImpulseEngine BaseImpulseEngine { get; }
    public Hull Hull { get; }
    public bool HasAntiNitrineEmitter { get; }
}