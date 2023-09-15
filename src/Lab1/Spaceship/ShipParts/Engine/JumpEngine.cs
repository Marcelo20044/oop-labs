namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Engine;

public abstract class JumpEngine : IEngine
{
    protected JumpEngine(int jumpDistance)
    {
        JumpDistance = jumpDistance;
    }

    public int JumpDistance { get; }
    public abstract void Start();
}