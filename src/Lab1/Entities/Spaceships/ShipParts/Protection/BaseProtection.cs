using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;

public abstract class BaseProtection
{
    public int AsteroidsCountReflect { get; set; }
    public int MeteoritesCountReflect { get; set; }
    public int SpaceWhalesCountReflect { get; set; }
    public StrengthClasses StrengthClass { get; private set; }
    public bool IsDestroyed { get; private set; }

    public void Destroy()
    {
        IsDestroyed = true;
    }

    protected void SetStrengthProperties(int asteroidsCountReflect, int meteoritesCountReflect, int spaceWhalesCountReflect, StrengthClasses strengthClass)
    {
        AsteroidsCountReflect = asteroidsCountReflect;
        MeteoritesCountReflect = meteoritesCountReflect;
        SpaceWhalesCountReflect = spaceWhalesCountReflect;
        StrengthClass = strengthClass;
        IsDestroyed = false;
    }
}