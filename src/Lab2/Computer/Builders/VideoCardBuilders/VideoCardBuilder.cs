using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.VideoCardBuilders;

public class VideoCardBuilder : IVideoCardBuilder
{
    private int _videoMemoryCount;
    private int _chipFrequency;
    private int _powerConsumption;
    private string? _pciEVersion;
    private Dimensions? _dimensions;

    public IVideoCardBuilder WithVideoMemoryCount(int memoryCount)
    {
        _videoMemoryCount = memoryCount;
        return this;
    }

    public IVideoCardBuilder WithChipFrequency(int frequency)
    {
        _chipFrequency = frequency;
        return this;
    }

    public IVideoCardBuilder WithPowerConsumption(int consumption)
    {
        _powerConsumption = consumption;
        return this;
    }

    public IVideoCardBuilder WithPciEVersion(string version)
    {
        _pciEVersion = version;
        return this;
    }

    public IVideoCardBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public IVideoCardBuilder Reset()
    {
        _videoMemoryCount = _chipFrequency = _powerConsumption = 0;
        _pciEVersion = null;
        _dimensions = null;

        return this;
    }

    public VideoCard Build()
    {
        int videoMemoryCount = _videoMemoryCount;
        int chipFrequency = _chipFrequency;
        int powerConsumption = _powerConsumption;
        string? pciEVersion = _pciEVersion;
        Dimensions? dimensions = _dimensions;

        Reset();

        return new VideoCard(
            videoMemoryCount,
            chipFrequency,
            powerConsumption,
            pciEVersion ?? throw new AttributeNullException(nameof(_pciEVersion)),
            dimensions ?? throw new AttributeNullException(nameof(_dimensions)));
    }
}