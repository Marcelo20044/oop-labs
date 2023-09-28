using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine.ImpulseEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.JumpEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.JumpEngine.JumpEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipModels;

public class AugurSpaceship : ISpaceshipWithDeflector, ISpaceshipWithJumpEngine
{
    public AugurSpaceship(BaseImpulseEngine impulseEngine, BaseJumpEngine jumpEngine, Deflector deflector, Hull hull, bool hasAntiNitrineEmitter = false)
    {
        if (impulseEngine is not ImpulseEngineE)
        {
            throw new ArgumentException("Augur can only have a class E impulse engine");
        }

        if (jumpEngine is not AlphaJumpEngine)
        {
            throw new ArgumentException("Augur can only have a class Alpha jump engine");
        }

        if (deflector is null || deflector.StrengthClass != StrengthClasses.Class3)
        {
            throw new ArgumentException("Augur can only have a third strength class deflector");
        }

        if (hull is null || hull.StrengthClass != StrengthClasses.Class3)
        {
            throw new ArgumentException("Augur can only have a third strength class hull");
        }

        BaseImpulseEngine = impulseEngine;
        JumpEngine = jumpEngine;
        Deflector = deflector;
        Hull = hull;
        HasAntiNitrineEmitter = hasAntiNitrineEmitter;
    }

    public BaseImpulseEngine BaseImpulseEngine { get; }
    public BaseJumpEngine JumpEngine { get; }
    public Deflector Deflector { get; set; }
    public Hull Hull { get; }
    public bool HasAntiNitrineEmitter { get; }

    public void SetPhotonDeflector()
    {
        Deflector.AntimatterFlaresCountReflect = 3;
    }
}