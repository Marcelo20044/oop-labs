namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine;

public abstract class BaseImpulseEngine : BaseEngine
{
    protected BaseImpulseEngine(int consumptionPerLightYear, int consumptionPerStart, int speed)
        : base(speed)
    {
        ActivePlasmaConsumptionPerLightYear = consumptionPerLightYear;
        ActivePlasmaConsumptionPerStart = consumptionPerStart;
    }

    public int ActivePlasmaConsumptionPerLightYear { get; }
    public int ActivePlasmaConsumptionPerStart { get; }
}