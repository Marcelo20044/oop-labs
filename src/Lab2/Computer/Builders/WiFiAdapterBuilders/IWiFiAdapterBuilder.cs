using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities.ComputerComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Builders.WiFiAdapterBuilders;

public interface IWiFiAdapterBuilder
{
    IWiFiAdapterBuilder WithPowerConsumption(int consumption);
    IWiFiAdapterBuilder WithBluetooth();
    IWiFiAdapterBuilder WithStandardVersion(string version);
    IWiFiAdapterBuilder WithPciEVersion(string version);
    IWiFiAdapterBuilder Reset();
    WiFiAdapter Build();
}