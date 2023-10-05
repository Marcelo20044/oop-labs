using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.JumpEngine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;

public interface ISpaceshipWithJumpEngine : ISpaceship
{
    public BaseJumpEngine JumpEngine { get; }
}