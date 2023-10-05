using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;

public interface ISpaceshipWithDeflector : ISpaceship
{
    public Deflector Deflector { get; set; }

    public void SetPhotonDeflector();
}