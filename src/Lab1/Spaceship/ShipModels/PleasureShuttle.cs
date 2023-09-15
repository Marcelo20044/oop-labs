using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipModels;

public class PleasureShuttle : Spaceship
{
    public PleasureShuttle()
        : base(new ImpulseEngineC(), new Deflector(StrengthClasses.NoClass), new Hull(StrengthClasses.Class1)) { }
}