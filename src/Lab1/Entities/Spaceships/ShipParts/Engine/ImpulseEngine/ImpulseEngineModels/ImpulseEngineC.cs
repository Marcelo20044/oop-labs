namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.ImpulseEngine.ImpulseEngineModels;

public class ImpulseEngineC : BaseImpulseEngine
{
    private const int FuelConsumptionPerLightYear = 150;
    private const int FuelConsumptionPerStart = 30;
    private const int SpeedInLightYearsPerHour = 20;
    public ImpulseEngineC()
        : base(FuelConsumptionPerLightYear, FuelConsumptionPerStart, SpeedInLightYearsPerHour) { }
}