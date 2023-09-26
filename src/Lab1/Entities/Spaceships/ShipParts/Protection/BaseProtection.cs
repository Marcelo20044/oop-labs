namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Protection;

public abstract class BaseProtection
{
    public int AsteroidsCountReflect { get; set; }
    public int MeteoritesCountReflect { get; set; }
    public int SpaceWhalesCountReflect { get; set; }

    protected void SetStrengthProperties(int asteroidsCountReflect, int meteoritesCountReflect, int spaceWhalesCountReflect)
    {
        AsteroidsCountReflect = asteroidsCountReflect;
        MeteoritesCountReflect = meteoritesCountReflect;
        SpaceWhalesCountReflect = spaceWhalesCountReflect;
    }
}