using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.HhdBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

public class Hdd : IComputerComponent
{
    public Hdd(int capacity, int spindleSpeed, int powerConsumption)
    {
        Capacity = capacity;
        SpindleSpeed = spindleSpeed;
        PowerConsumption = powerConsumption;
    }

    public int Capacity { get; }
    public int SpindleSpeed { get; }
    public int PowerConsumption { get; }

    public IHddBuilder Direct(IHddBuilder builder)
    {
        if (builder is null) throw new BuilderNullException(nameof(builder));

        return builder
            .WithCapacity(Capacity)
            .WithSpindleSpeed(SpindleSpeed)
            .WithPowerConsumption(PowerConsumption);
    }
}