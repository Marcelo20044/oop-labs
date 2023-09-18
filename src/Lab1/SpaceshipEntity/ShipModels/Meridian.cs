using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Engine.ImpulseEngineEntity.ImpulseEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipModels;

public class Meridian : SpaceshipEntity.Spaceship
{
    public Meridian()
        : base(new ImpulseEngineE(), new Deflector(StrengthClasses.Class2), new Hull(StrengthClasses.Class2), true) { }
}