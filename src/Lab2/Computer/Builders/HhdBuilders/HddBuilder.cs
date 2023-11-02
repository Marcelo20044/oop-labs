using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.HhdBuilders;

public class HddBuilder : IHddBuilder
{
    private int _capacity;
    private int _spindleSpeed;
    private int _powerConsumption;

    public IHddBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public IHddBuilder WithSpindleSpeed(int speed)
    {
        _spindleSpeed = speed;
        return this;
    }

    public IHddBuilder WithPowerConsumption(int consumption)
    {
        _powerConsumption = consumption;
        return this;
    }

    public IHddBuilder Reset()
    {
        _capacity = _spindleSpeed = _powerConsumption = 0;
        return this;
    }

    public Hdd Build()
    {
        int capacity = _capacity;
        int spindleSpeed = _spindleSpeed;
        int powerConsumption = _powerConsumption;

        Reset();

        return new Hdd(
            capacity,
            spindleSpeed,
            powerConsumption);
    }
}