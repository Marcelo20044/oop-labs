using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipModels;

public class Stella : SpaceshipEntity.Spaceship
{
    public Stella()
        : base(new ImpulseEngineC(), new OmegaJumpEngine(), new Deflector(StrengthClasses.Class1), new Hull(StrengthClasses.Class1)) { }
}