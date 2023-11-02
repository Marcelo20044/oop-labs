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

    public IWiFiAdapterBuilder Reset()
    {
        _powerConsumption = 0;
        _hasBluetooth = false;
        _standardVersion = null;
        _pciEVersion = null;

        return this;
    }

    public WiFiAdapter Build()
    {
        int powerConsumption = _powerConsumption;
        bool hasBluetooth = _hasBluetooth;
        string? standardVersion = _standardVersion;
        string? pciEVersion = _pciEVersion;

        Reset();

        return new WiFiAdapter(
            powerConsumption,
            hasBluetooth,
            standardVersion ?? throw new AttributeNullException(nameof(_standardVersion)),
            pciEVersion ?? throw new AttributeNullException(nameof(_pciEVersion)));
    }
}