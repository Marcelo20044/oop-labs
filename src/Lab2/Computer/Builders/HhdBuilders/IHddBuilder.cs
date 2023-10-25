using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.HhdBuilders;

public interface IHddBuilder
{
    IHddBuilder WithCapacity(int capacity);
    IHddBuilder WithSpindleSpeed(int speed);
    IHddBuilder WithPowerConsumption(int consumption);
    IHddBuilder Reset();
    Hdd Build();
}