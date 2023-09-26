using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine.ImpulseEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.JumpEngine.JumpEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipModels;

public class VaklasSpaceship : BaseSpaceship
{
    public VaklasSpaceship()
        : base(new ImpulseEngineE(), new Deflector(StrengthClasses.Class1), new Hull(StrengthClasses.Class2), jumpEngine: new GammaJumpEngine()) { }
}