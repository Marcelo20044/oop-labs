namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Engine;

public abstract class ImpulseEngine
{
    protected ImpulseEngine(int consumptionPerLightYear, int consumptionPerStart, int speed)
    {
        ActivePlasmaConsumptionPerLightYear = consumptionPerLightYear;
        ActivePlasmaConsumptionPerStart = consumptionPerStart;
        SpeedInLightYearsPerHour = speed;
    }

    public int ActivePlasmaConsumptionPerLightYear { get; }
    public int ActivePlasmaConsumptionPerStart { get; }
    public int SpeedInLightYearsPerHour { get; }
    public abstract void Start();
}