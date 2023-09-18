using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Engine.ImpulseEngineEntity.ImpulseEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipModels;

public class PleasureShuttle : SpaceshipEntity.Spaceship
{
    public PleasureShuttle()
        : base(new ImpulseEngineC(), null, new Hull(StrengthClasses.Class1)) { }
}