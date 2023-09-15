namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.ShipParts.Protection;

public abstract class Protection
{
    public int AsteroidCountReflect { get; private set; }
    public int MeteoriteCountReflect { get; private set; }
    public int SpaceWhaleCountReflect { get; private set; }

    protected void SetStrengthProperties(int asteroidCountReflect, int meteoriteCountReflect, int spaceWhaleCountReflect)
    {
        AsteroidCountReflect = asteroidCountReflect;
        MeteoriteCountReflect = meteoriteCountReflect;
        SpaceWhaleCountReflect = spaceWhaleCountReflect;
    }
}