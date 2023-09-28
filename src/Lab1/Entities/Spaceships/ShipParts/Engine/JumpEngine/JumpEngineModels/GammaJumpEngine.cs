namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.JumpEngine.JumpEngineModels;

public class GammaJumpEngine : BaseJumpEngine
{
    private const int JumpDistanceInLightYears = 65;
    private const int FuelConsumptionPerLightYear = 1200;
    private const int SpeedInLightYearsPerHour = 100;
    public GammaJumpEngine()
        : base(JumpDistanceInLightYears, FuelConsumptionPerLightYear, SpeedInLightYearsPerHour) { }
}