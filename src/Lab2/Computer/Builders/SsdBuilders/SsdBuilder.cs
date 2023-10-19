using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.SsdBuilders;

public class SsdBuilder : ISsdBuilder
{
    private int _capacity;
    private int _maxOperationSpeed;
    private int _powerConsumption;
    private SsdConnectOption _connectOption;

    public ISsdBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public ISsdBuilder WithMaxOperationSpeed(int speed)
    {
        _maxOperationSpeed = speed;
        return this;
    }

    public ISsdBuilder WithPowerConsumption(int consumption)
    {
        _powerConsumption = consumption;
        return this;
    }

    public ISsdBuilder WithConnectOption(SsdConnectOption connectOption)
    {
        _connectOption = connectOption;
        return this;
    }

    public Ssd Build()
    {
        return new Ssd(
            _capacity,
            _maxOperationSpeed,
            _powerConsumption,
            _connectOption);
    }
}