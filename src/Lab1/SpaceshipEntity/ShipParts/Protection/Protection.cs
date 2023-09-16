namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Protection;

public abstract class Protection
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