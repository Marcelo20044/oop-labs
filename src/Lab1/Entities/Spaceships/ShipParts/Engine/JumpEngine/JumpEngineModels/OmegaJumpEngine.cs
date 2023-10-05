namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.JumpEngine.JumpEngineModels;

public class OmegaJumpEngine : BaseJumpEngine
{
    private const int JumpDistanceInLightYears = 45;
    private const int FuelConsumptionPerLightYear = 250;
    private const int SpeedInLightYearsPerHour = 75;
    public OmegaJumpEngine()
        : base(JumpDistanceInLightYears, FuelConsumptionPerLightYear, SpeedInLightYearsPerHour) { }
}