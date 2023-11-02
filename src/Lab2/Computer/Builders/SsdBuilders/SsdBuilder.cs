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

    public ISsdBuilder Reset()
    {
        _capacity = _maxOperationSpeed = _powerConsumption = 0;

        return this;
    }

    public Ssd Build()
    {
        int capacity = _capacity;
        int maxOperationSpeed = _maxOperationSpeed;
        int powerConsumption = _powerConsumption;
        SsdConnectOption connectOption = _connectOption;

        Reset();

        return new Ssd(
            capacity,
            maxOperationSpeed,
            powerConsumption,
            connectOption);
    }
}