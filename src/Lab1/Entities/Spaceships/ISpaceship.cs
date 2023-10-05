using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;

public interface ISpaceship
{
    public BaseImpulseEngine BaseImpulseEngine { get; }
    public Hull Hull { get; }
    public bool HasAntiNitrineEmitter { get; }
}