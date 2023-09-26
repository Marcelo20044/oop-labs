using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine.ImpulseEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.JumpEngine.JumpEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipModels;

public class AugurSpaceship : BaseSpaceship
{
    public AugurSpaceship()
        : base(new ImpulseEngineE(), new Deflector(StrengthClasses.Class3), new Hull(StrengthClasses.Class3), jumpEngine: new AlphaJumpEngine()) { }
}