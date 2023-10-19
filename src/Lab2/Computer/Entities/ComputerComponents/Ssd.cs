using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.SsdBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

public class Ssd : IComputerComponent
{
    public Ssd(
        int capacity,
        int maxOperatingSpeed,
        int powerConsumption,
        SsdConnectOption connectOption)
    {
        Capacity = capacity;
        MaxOperatingSpeed = maxOperatingSpeed;
        PowerConsumption = powerConsumption;
        ConnectOption = connectOption;
    }

    public int Capacity { get; }
    public int MaxOperatingSpeed { get; }
    public int PowerConsumption { get; }
    private SsdConnectOption ConnectOption { get; }

    public ISsdBuilder Direct(ISsdBuilder builder)
    {
        if (builder is null) throw new BuilderNullException(nameof(builder));

        return builder
            .WithCapacity(Capacity)
            .WithMaxOperationSpeed(MaxOperatingSpeed)
            .WithPowerConsumption(PowerConsumption)
            .WithConnectOption(ConnectOption);
    }
}