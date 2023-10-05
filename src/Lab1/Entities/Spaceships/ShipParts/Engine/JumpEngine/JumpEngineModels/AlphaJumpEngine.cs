namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.JumpEngine.JumpEngineModels;

public class AlphaJumpEngine : BaseJumpEngine
{
    private const int JumpDistanceInLightYears = 25;
    private const int FuelConsumptionPerLightYear = 25;
    private const int SpeedInLightYearsPerHour = 50;
    public AlphaJumpEngine()
        : base(JumpDistanceInLightYears, FuelConsumptionPerLightYear, SpeedInLightYearsPerHour) { }
}