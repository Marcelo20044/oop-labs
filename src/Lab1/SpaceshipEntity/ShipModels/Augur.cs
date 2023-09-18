using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Engine.ImpulseEngineEntity.ImpulseEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Engine.JumpEngineEntity.JumpEngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipModels;

public class Augur : SpaceshipEntity.Spaceship
{
    public Augur()
        : base(new ImpulseEngineE(), new AlphaJumpEngine(), new Deflector(StrengthClasses.Class3), new Hull(StrengthClasses.Class3)) { }
}