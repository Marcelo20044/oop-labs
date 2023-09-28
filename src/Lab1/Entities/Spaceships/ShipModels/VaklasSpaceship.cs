using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine.ImpulseEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.JumpEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.JumpEngine.JumpEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipModels;

public class VaklasSpaceship : ISpaceshipWithDeflector, ISpaceshipWithJumpEngine
{
    public VaklasSpaceship(BaseImpulseEngine impulseEngine, BaseJumpEngine jumpEngine, Deflector deflector, Hull hull, bool hasAntiNitrineEmitter = false)
    {
        if (impulseEngine is not ImpulseEngineE)
        {
            throw new ArgumentException("Vaklas can only have a class E impulse engine");
        }

        if (jumpEngine is not GammaJumpEngine)
        {
            throw new ArgumentException("Vaklas can only have a class Gamma jump engine");
        }

        if (deflector is null || deflector.StrengthClass != StrengthClasses.Class1)
        {
            throw new ArgumentException("Vaklas can only have a first strength class deflector");
        }

        if (hull is null || hull.StrengthClass != StrengthClasses.Class2)
        {
            throw new ArgumentException("Vaklas can only have a second strength class hull");
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