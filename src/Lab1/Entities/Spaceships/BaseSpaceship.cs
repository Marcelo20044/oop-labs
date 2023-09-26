using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.JumpEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships;

public abstract class BaseSpaceship
{
    protected BaseSpaceship(BaseImpulseEngine engine, Deflector? deflector, Hull hull, bool hasAntiNitrineEmitter = false, BaseJumpEngine? jumpEngine = null)
    {
        BaseImpulseEngine = engine;
        Deflector = deflector;
        Hull = hull;
        HasAntiNitrineEmitter = hasAntiNitrineEmitter;
        JumpEngine = jumpEngine;
    }

    public BaseImpulseEngine BaseImpulseEngine { get; }
    public BaseJumpEngine? JumpEngine { get; }
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