using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine.ImpulseEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipModels;

public class PleasureShuttleSpaceship : BaseSpaceship
{
    public PleasureShuttleSpaceship()
        : base(new ImpulseEngineC(), null, new Hull(StrengthClasses.Class1)) { }
}