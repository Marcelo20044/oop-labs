using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine.ImpulseEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipModels;

public class MeridianSpaceship : BaseSpaceship
{
    public MeridianSpaceship()
        : base(new ImpulseEngineE(), new Deflector(StrengthClasses.Class2), new Hull(StrengthClasses.Class2), true) { }
}