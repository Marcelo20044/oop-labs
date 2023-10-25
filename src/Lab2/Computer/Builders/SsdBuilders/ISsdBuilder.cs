using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.SsdBuilders;

public interface ISsdBuilder
{
    ISsdBuilder WithCapacity(int capacity);
    ISsdBuilder WithMaxOperationSpeed(int speed);
    ISsdBuilder WithPowerConsumption(int consumption);
    ISsdBuilder WithConnectOption(SsdConnectOption connectOption);
    ISsdBuilder Reset();
    Ssd Build();
}