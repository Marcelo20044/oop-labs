using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.VideoCardBuilders;

public interface IVideoCardBuilder
{
    IVideoCardBuilder WithVideoMemoryCount(int memoryCount);
    IVideoCardBuilder WithChipFrequency(int frequency);
    IVideoCardBuilder WithPowerConsumption(int consumption);
    IVideoCardBuilder WithPciEVersion(string version);
    IVideoCardBuilder WithDimensions(Dimensions dimensions);
    IVideoCardBuilder Reset();
    VideoCard Build();
}