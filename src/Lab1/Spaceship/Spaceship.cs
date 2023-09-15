using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public abstract class Spaceship
{
    protected Spaceship(ImpulseEngine engine, Deflector? deflector, Hull hull, bool hasAntiNitrineEmitter = false, JumpEngine? jumpEngine = null)
    {
        Engine = engine;
        Deflector = deflector;
        Hull = hull;
        HasAntiNitrineEmitter = hasAntiNitrineEmitter;
        JumpEngine = jumpEngine;
    }

    // Constructor for ship with Jump Engine
    protected Spaceship(ImpulseEngine engine, JumpEngine? jumpEngine, Deflector? deflector, Hull hull, bool hasAntiNitrineEmitter = false)
        : this(engine, deflector, hull, hasAntiNitrineEmitter, jumpEngine) { }

    public ImpulseEngine Engine { get; }
    public JumpEngine? JumpEngine { get; }
    public Deflector? Deflector { get; private set; }
    public Hull Hull { get; }
    public bool HasAntiNitrineEmitter { get; }

    public void DestroyDeflector()
    {
        Deflector = null;
    }
}