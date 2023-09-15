using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipModels;

public class Augur : Spaceship
{
    public Augur()
        : base(new ImpulseEngineE(), new AlphaJumpEngine(), new Deflector(StrengthClasses.Class3), new Hull(StrengthClasses.Class3)) { }
}