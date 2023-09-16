using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipModels;

public class Vaklas : SpaceshipEntity.Spaceship
{
    public Vaklas()
        : base(new ImpulseEngineE(), new GammaJumpEngine(), new Deflector(StrengthClasses.Class1), new Hull(StrengthClasses.Class2)) { }
}