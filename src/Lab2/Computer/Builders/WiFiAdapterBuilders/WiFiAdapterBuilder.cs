using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.WiFiAdapterBuilders;

public class WiFiAdapterBuilder : IWiFiAdapterBuilder
{
    private int _powerConsumption;
    private bool _hasBluetooth;
    private string? _standardVersion;
    private string? _pciEVersion;

    public IWiFiAdapterBuilder WithPowerConsumption(int consumption)
    {
        _powerConsumption = consumption;
        return this;
    }

    public IWiFiAdapterBuilder WithBluetooth()
    {
        _hasBluetooth = true;
        return this;
    }

    public IWiFiAdapterBuilder WithStandardVersion(string version)
    {
        _standardVersion = version;
        return this;
    }

    public IWiFiAdapterBuilder WithPciEVersion(string version)
    {
        _pciEVersion = version;
        return this;
    }

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(
            _powerConsumption,
            _hasBluetooth,
            _standardVersion ?? throw new AttributeNullException(nameof(_standardVersion)),
            _pciEVersion ?? throw new AttributeNullException(nameof(_pciEVersion)));
    }
}