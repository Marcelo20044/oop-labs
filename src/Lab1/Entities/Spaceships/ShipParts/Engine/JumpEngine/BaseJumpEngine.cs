namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaceships.ShipParts.Engine.JumpEngine;

public abstract class BaseJumpEngine : BaseEngine
{
    protected BaseJumpEngine(int jumpDistance, int consumptionPerLightYear, int speed)
        : base(speed)
    {
        JumpDistance = jumpDistance;
        GravitationalMatterConsumptionPerLightYear = consumptionPerLightYear;
    }

    public int JumpDistance { get; }
    public int GravitationalMatterConsumptionPerLightYear { get; }
}