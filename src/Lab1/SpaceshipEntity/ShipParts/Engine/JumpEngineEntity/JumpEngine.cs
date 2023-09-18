namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceshipEntity.ShipParts.Engine.JumpEngineEntity;

public abstract class JumpEngine
{
    protected JumpEngine(int jumpDistance, int consumptionPerLightYear)
    {
        JumpDistance = jumpDistance;
        GravitationalMatterConsumptionPerLightYear = consumptionPerLightYear;
    }

    public int JumpDistance { get; }
    public int GravitationalMatterConsumptionPerLightYear { get; }
}