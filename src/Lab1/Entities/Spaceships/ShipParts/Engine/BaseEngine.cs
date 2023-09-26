namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine;

public class BaseEngine
{
    protected BaseEngine(int speed)
    {
        Speed = speed;
    }

    public int Speed { get; }
}