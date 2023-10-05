namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine.ImpulseEngineModels;

public class ImpulseEngineE : BaseImpulseEngine
{
    private const int FuelConsumptionPerLightYear = 320;
    private const int FuelConsumptionPerStart = 50;
    private const int SpeedInLightYearsPerHour = 40;
    public ImpulseEngineE()
        : base(FuelConsumptionPerLightYear, FuelConsumptionPerStart, SpeedInLightYearsPerHour) { }
}