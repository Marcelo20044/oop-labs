using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipModels;

public class Meridian : Spaceship
{
    public Meridian()
        : base(new ImpulseEngineE(), new Deflector(StrengthClasses.Class2), new Hull(StrengthClasses.Class2), true) { }
}