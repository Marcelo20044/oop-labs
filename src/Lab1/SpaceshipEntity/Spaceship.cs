using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Engine.ImpulseEngineEntity;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Engine.JumpEngineEntity;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity;

public abstract class Spaceship
{
    protected Spaceship(ImpulseEngine engine, Deflector? deflector, Hull hull, bool hasAntiNitrineEmitter = false, JumpEngine? jumpEngine = null)
    {
        ImpulseEngine = engine;
        Deflector = deflector;
        Hull = hull;
        HasAntiNitrineEmitter = hasAntiNitrineEmitter;
        JumpEngine = jumpEngine;
    }

    // Constructor for ship with Jump Engine
    protected Spaceship(ImpulseEngine engine, JumpEngine? jumpEngine, Deflector? deflector, Hull hull, bool hasAntiNitrineEmitter = false)
        : this(engine, deflector, hull, hasAntiNitrineEmitter, jumpEngine) { }

    public ImpulseEngine ImpulseEngine { get; }
    public JumpEngine? JumpEngine { get; }
    public Deflector? Deflector { get; private set; }
    public Hull Hull { get; }
    public bool HasAntiNitrineEmitter { get; }

    public void DestroyDeflector()
    {
        Deflector = null;
    }

    public void SetPhotonDeflector()
    {
        if (Deflector is null)
        {
            throw new ArgumentNullException(nameof(Deflector), "Regular deflector is null. You can't set photon deflector without regular deflector");
        }

        Deflector.AntimatterFlaresCountReflect = 3;
    }
}