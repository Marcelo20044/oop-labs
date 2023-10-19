using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.VideoCardBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

public class VideoCard : IComputerComponent
{
    public VideoCard(
        int videoMemoryCount,
        int chipFrequency,
        int powerConsumption,
        string pciEVersion,
        Dimensions dimensions)
    {
        VideoMemoryCount = videoMemoryCount;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
        PciEVersion = pciEVersion;
        Dimensions = dimensions;
    }

    public int VideoMemoryCount { get; }
    public int ChipFrequency { get; }
    public int PowerConsumption { get; }
    public string PciEVersion { get; }
    public Dimensions Dimensions { get; }

    public IVideoCardBuilder Direct(IVideoCardBuilder builder)
    {
        if (builder is null) throw new BuilderNullException(nameof(builder));

        return builder
            .WithVideoMemoryCount(VideoMemoryCount)
            .WithChipFrequency(ChipFrequency)
            .WithPowerConsumption(PowerConsumption)
            .WithPciEVersion(PciEVersion)
            .WithDimensions(Dimensions);
    }
}