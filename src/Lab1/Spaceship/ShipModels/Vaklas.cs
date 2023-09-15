using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipModels;

public class Vaklas : Spaceship
{
    public Vaklas()
        : base(new ImpulseEngineE(), new GammaJumpEngine(), new Deflector(StrengthClasses.Class1), new Hull(StrengthClasses.Class2)) { }
}