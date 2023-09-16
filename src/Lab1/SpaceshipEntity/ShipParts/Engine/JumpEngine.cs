namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Engine;

public abstract class JumpEngine
{
    protected JumpEngine(int jumpDistance, int consumptionPerLightYear, int speed)
    {
        JumpDistance = jumpDistance;
        GravitationalMatterConsumptionPerLightYear = consumptionPerLightYear;
        SpeedInLightYearsPerHour = speed;
    }

    public int JumpDistance { get; }
    public int GravitationalMatterConsumptionPerLightYear { get; }
    public int SpeedInLightYearsPerHour { get; }
    public abstract void Start();
}