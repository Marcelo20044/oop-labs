using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipModels;

public class Stella : Spaceship
{
    public Stella()
        : base(new ImpulseEngineC(), new OmegaJumpEngine(), new Deflector(StrengthClasses.Class1), new Hull(StrengthClasses.Class1)) { }
}