using Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.WiFiAdapterBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

public class WiFiAdapter : IComputerComponent
{
    public WiFiAdapter(
        int powerConsumption,
        bool hasBluetooth,
        string standardVersion,
        string pciEVersion)
    {
        PowerConsumption = powerConsumption;
        HasBluetooth = hasBluetooth;
        StandardVersion = standardVersion;
        PciEVersion = pciEVersion;
    }

    public int PowerConsumption { get; }
    public bool HasBluetooth { get; }
    public string StandardVersion { get; }
    public string PciEVersion { get; }

    // Debuilder for getting Wi-Fi Adapter builder based on finished one
    public IWiFiAdapterBuilder Direct(IWiFiAdapterBuilder builder)
    {
        if (builder is null) throw new BuilderNullException(nameof(builder));

        builder
            .WithPowerConsumption(PowerConsumption)
            .WithStandardVersion(StandardVersion)
            .WithPciEVersion(PciEVersion);

        return HasBluetooth ? builder.WithBluetooth() : builder;
    }
}